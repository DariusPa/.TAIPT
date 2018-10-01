using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.dbcontact
{
    class dbClass
    {
        public string name{ get; set;}
        public string surname { get; set; }
        public string email { get; set; }
        public int UID { get; set; }


        static string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
            
        //Selecting data from the Database

        public DataTable Select()
        {
            //database connection
            SqlConnection conn = new SqlConnection(connectionString);
            DataTable dt = new DataTable();
            try
            {
                //Writing SQL query
                string query = "SELECT * from user_data";
                //creating command using query and conn
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);


            }

            catch (Exception ex)
            {

            }



            finally
            {
                conn.Close();
            }
            return dt;
        }


        //Inserting data into db
        public bool Insert(dbClass c)
        {
            bool isSuccess = false;
            //database connection
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                //Writing SQL query
                string query = "INSERT INTO user_data (Name, Surname, EmailAdress) VALUES(@Name, @Surname, @EmailAdress)";
                
                
                //creating command using query and conn
                SqlCommand cmdInsert = new SqlCommand(query, conn);
                
                
                //Create parameters to add data
                cmdInsert.Parameters.AddWithValue("@Name", c.name);
                cmdInsert.Parameters.AddWithValue("@Surname", c.surname);
                cmdInsert.Parameters.AddWithValue("@EmailAdress", c.email);

                
                
                //open connection

                conn.Open();
                int rows = cmdInsert.ExecuteNonQuery();
                //if the query runs successfully, the value of rows will be greater than 0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                    isSuccess = false;
            }

            catch (Exception ex)
            {

            }



            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        //method to update data in database from app

        public bool Update (dbClass c)
        {
            bool isSuccess = false;
            //database connection
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                //Writing SQL query
                string query = "UPDATE user_data SET Name=@Name, Surname=@Surname, EmailAdress=@EmailAdress WHERE UID=@UID";
                
                
                //creating command using query and conn
                SqlCommand cmd = new SqlCommand(query, conn);
                
                
                //Create parameters to add data
                cmd.Parameters.AddWithValue("@Name", c.name);
                cmd.Parameters.AddWithValue("@Surname", c.surname);
                cmd.Parameters.AddWithValue("@EmailAdress", c.email);
                cmd.Parameters.AddWithValue("@UID", c.UID);



                //open connection

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //if the query runs successfully, the value of rows will be greater than 0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                    isSuccess = false;
            }

            catch (Exception ex)
            {

            }



            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
    }
}
