using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace FaceDB
{
    class PostGreSQL
    {
        public void PostgreSQL() {}

        public List<string> GetUidList()
        {
            try
            {
                string connstring = "Server=127.0.0.1; Port=5432; User Id=postgres; Password=h*!J45R^sntuz; Database=facedb;";
                NpgsqlConnection connection = new NpgsqlConnection(connstring);
                connection.Open();
                List<string> dataItems = new List<string>();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT userid FROM regforms.tb", connection);
                NpgsqlDataReader dataReader = cmd.ExecuteReader();
                for (int i = 0; dataReader.Read(); i++)
                {
                    dataItems.Add(dataReader[0].ToString() + "\r\n");
                }
                connection.Close();
                return dataItems;
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
                throw;
            }



        }

        public List<string> GetNameList()
        {
            try
            {
                string connstring = "Server=127.0.0.1; Port=5432; User Id=postgres; Password=h*!J45R^sntuz; Database=facedb;";
                NpgsqlConnection connection = new NpgsqlConnection(connstring);
                connection.Open();
                List<string> dataItems = new List<string>();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT name FROM regforms.tb", connection);
                NpgsqlDataReader dataReader = cmd.ExecuteReader();
                for (int i = 0; dataReader.Read(); i++)
                {
                    dataItems.Add(dataReader[0].ToString() + "\r\n");
                }
                connection.Close();
                return dataItems;
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
                throw;
            }



        }

        public List<string> GetSurnameList()
        {
            try
            {
                string connstring = "Server=127.0.0.1; Port=5432; User Id=postgres; Password=h*!J45R^sntuz; Database=facedb;";
                NpgsqlConnection connection = new NpgsqlConnection(connstring);
                connection.Open();
                List<string> dataItems = new List<string>();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT surname FROM regforms.tb", connection);
                NpgsqlDataReader dataReader = cmd.ExecuteReader();
                for (int i = 0; dataReader.Read(); i++)
                {
                    dataItems.Add(dataReader[0].ToString() + "\r\n");
                }
                connection.Close();
                return dataItems;
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
                throw;
            }



        }

        public void InsertData(string name, string surname)
        {
            try
            {
                string connstring = "Server=127.0.0.1; Port=5432; User Id=postgres; Password=h*!J45R^sntuz; Database=facedb;";
                NpgsqlConnection connection = new NpgsqlConnection(connstring);
                connection.Open();
                NpgsqlCommand inCommand = new NpgsqlCommand("INSERT INTO regforms.tb VALUES (DEFAULT, '"+name+"', '"+surname+"');", connection);
                inCommand.ExecuteNonQuery();
                MessageBox.Show("Inserted: "+name+" "+surname+ " into the facedb database");
                connection.Close();
            } catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
                throw;
            }
            
        }
    }
}
