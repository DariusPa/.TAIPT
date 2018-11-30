using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VirtualLibrarian.Data;

namespace VirtualLibrarian.Helpers
{
    public static class DataTransformationUtility
    {


        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Enums are converted to strings
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                type = type.BaseType == typeof(Enum) ? typeof(string) : type;

                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].PropertyType.BaseType == typeof(Enum) ? Props[i].GetValue(item, null).ToString() : Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        public static DataTable RemoveUnusedColumns(DataTable dt, string[] columns)
        {
            var newDt = new DataTable();
            foreach (DataColumn col in dt.Columns)
            {
                if (columns.Contains(col.ColumnName))
                {
                    newDt.Columns.Add(col.ColumnName);
                }
            }
            foreach (DataRow row in dt.Rows)
            {
                var newRow = newDt.NewRow();
                foreach (string column in columns)
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
                foreach (string column in filteredColumns)
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

        public static List<Bitmap> StringToBitmapList(List<string> stringList)
        {
            var byteArrays = new List<byte[]>();
            var bitmaps = new List<Bitmap>();
            foreach (string element in stringList)
            {
                bitmaps.Add(StringToBitmap(element));
            }
            return bitmaps;
        }

        public static Bitmap StringToBitmap(string stringValue)
        {
            var base64Data = Regex.Match(stringValue, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            var binData = Convert.FromBase64String(base64Data);
            using (var stream = new MemoryStream(binData))
            {
                var byteArray = stream.ToArray();
                using(var byteStream = new MemoryStream(byteArray))
                {
                    return new Bitmap(stream);
                }
            }
        }

        public static Image<Gray,byte> BitmapToGrayImage(Bitmap bitmap)
        {
            var grayImg = new Image<Gray, byte>(bitmap);
            CvInvoke.Resize(grayImg, grayImg, new Size(100, 100), 0, 0, Inter.Cubic);
            CvInvoke.EqualizeHist(grayImg, grayImg);
            return grayImg;
        }

        public static List<Image<Gray,byte>> BitmapToGrayImageList(List<Bitmap> bitmaps)
        {
            var images = new List<Image<Gray, byte>>();
            foreach (Bitmap bmp in bitmaps)
            {
                images.Add(BitmapToGrayImage(bmp));
            }
            return images;
        }


    }
}
