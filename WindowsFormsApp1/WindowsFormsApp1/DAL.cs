﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class DAL
    {
        public static DataTable ExecSP(string spName, List<SqlParameter> sqlParams = null)
        {
            string strConnect = "Server=DESKTOP-5FF4H1J;Database=fdb;Trusted_Connection=True;";

            SqlConnection conn = new SqlConnection();

            DataTable dt = new DataTable();

            try
            {
                //connect to the database
                conn = new SqlConnection(strConnect);
                conn.Open();


                //create an sql command/query
                SqlCommand cmd = new SqlCommand(spName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(sqlParams.ToArray());

                //execute command
                SqlCommand command = conn.CreateCommand();
                SqlDataReader dr = cmd.ExecuteReader();

                //fill datatable with the results
                dt.Load(dr);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
    }
}
