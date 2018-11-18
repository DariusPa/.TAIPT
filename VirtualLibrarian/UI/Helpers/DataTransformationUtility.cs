using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrarian.Data;

namespace VirtualLibrarian.Helpers
{
    public static class DataTransformationUtility
    {
        //TODO: convert enum so string 
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance );
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        public static DataTable RemoveUnusedColumns(DataTable dt, string[] columns)
        {
            var newDt = new DataTable();
            foreach(DataColumn col in dt.Columns)
            {
                if (columns.Contains(col.ColumnName))
                {
                    newDt.Columns.Add(col.ColumnName);
                }
            }
            foreach(DataRow row in dt.Rows)
            {
                var newRow = newDt.NewRow();
                foreach(string column in columns)
                {
                    newRow[column] = row[column];
                }
                newDt.Rows.Add(newRow);
            }
            return newDt;
        }


        //Adds additional column to DataTable for filtering values
        public static void EnableFiltering(DataTable dataTable, params string[] filteredColumns)
        {
            DataColumn dcRowString = dataTable.Columns.Add("_RowString", typeof(string));
            foreach (DataRow dataRow in dataTable.Rows)
            {
                StringBuilder sb = new StringBuilder();
                foreach(string column in filteredColumns)
                {
                    sb.Append(dataRow[column].ToString());
                    sb.Append("\t");
                }
                dataRow[dcRowString] = sb.ToString();
            }
        }

        //TODO: might need to move somewhere else
        public static string GetAuthorNames(List<int> authorID)
        {
            return string.Join(",", authorID
                          .Join(LibraryDataIO.Instance.Authors,
                          author => author,
                          lbAuthor => lbAuthor.ID,
                          (author, lbAuthor) => lbAuthor.FullName));
        }

    }
}
