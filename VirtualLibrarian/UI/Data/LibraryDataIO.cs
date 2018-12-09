using Emgu.CV;
using Emgu.CV.Structure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VirtualLibrarian.BusinessLogic;
using VirtualLibrarian.Helpers;
using VirtualLibrarian.Model;

namespace VirtualLibrarian.Data
{
    public sealed class LibraryDataIO
    {
        public string FacesPath { get; set; }
        public string DataDirPath { get; set; }
        public string ResourcePath { get; set; }
        public int PicturesPerUser { get; set; }

        public LibraryContext Context { get; private set; }

        public ILogger Logger { get; set; }
        public UILogger UILogger { get; set; }

        public string ConnectionString { get; set; }

        private static readonly Lazy<LibraryDataIO> library = new Lazy<LibraryDataIO>(() => new LibraryDataIO());
        public static LibraryDataIO Instance { get { return library.Value; } }

        private LibraryDataIO() { }

        public void Init(string connectionString, string directory, string facesPath, int picturesPerUser = 10)
        {
            DataDirPath = directory + StringConstants.dataDirPath;
            FacesPath = DataDirPath + facesPath;
            ResourcePath = directory + StringConstants.resourcePath;
            FacesPath = DataDirPath + facesPath;
            PicturesPerUser = picturesPerUser;

            ConnectionString = connectionString;
            Context = new LibraryContext(connectionString);

            Logger = new FileLogger(directory);
            UILogger = new UILogger();
        }

        public void AddPublisher(string name, string country, string description)
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                var insert = new SqlCommand();
                insert.Connection = cn;
                insert.CommandType = CommandType.Text;
                insert.CommandText = "INSERT INTO Publishers (Name, Country,Description) VALUES(@N,@C,@D)";

                insert.Parameters.Add(new SqlParameter("@N", SqlDbType.NVarChar, 30, "Name"));
                insert.Parameters.Add(new SqlParameter("@C", SqlDbType.NVarChar, 30, "Country"));
                insert.Parameters.Add(new SqlParameter("@D", SqlDbType.NVarChar, 30, "Description"));

                var da = new SqlDataAdapter("SELECT ID, Name, Country, Description FROM Publishers", cn);
                da.InsertCommand = insert;

                var dt = new DataTable();
                da.Fill(dt);

                var newPublisherRow = dt.NewRow();
                newPublisherRow["Name"] = name;
                newPublisherRow["Country"] = country;
                newPublisherRow["Description"] = description;
                dt.Rows.Add(newPublisherRow);

                da.Update(dt);
                cn.Close();
                da.Dispose();
            }
        }

        public void AddAuthor(Author author)
        {
            Context.Authors.Add(author);
            SaveChanges();
        }


        public void AddBook(Book book)
        {
            Context.Books.Add(book);
            SaveChanges();
        }

        public void AddUser(User user)
        {
            Context.Users.Add(user);
            SaveChanges();
        }

        public void RemoveUser(User user)
        {
            Context.Users.Remove(user);
            SaveChanges();
        }

        public void RemoveBook(Book book)
        {
            using(var cn = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand("DELETE FROM Books WHERE ID = @id",cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id",book.ID);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void AddFace(Image<Gray, byte> face, string label, int faceCount)
        {
            try
            {
                var user = FindUser(int.Parse(label));
                var path = $"{FacesPath}\\{faceCount}.bmp";
                face.Save(path);
                Context.Faces.Add(new Face(user, path));
                SaveChanges();
            }
            catch (Exception e)
            {
                Logger.LogException(e);
                UILogger.LogError(StringConstants.saveFaceErrror);
            }

        }

        public User FindUser(int ID)
        {
            return Context.Users.Where(u => u.ID == ID).Single();
        }

        public Book FindBook(int ID)
        {
            return Context.Books.Where(b => b.ID == ID).Single();
        }

        public Author FindAuthor(int ID)
        {
            return Context.Authors.Where(a => a.ID == ID).Single();
        }

        public Publisher FindPublisher(int ID)
        {
            return Context.Publishers.Where(p => p.ID == ID).Single();
        }

        public void ChangeUserInfo(int ID, string name, string surname, string email, string phone)
        {
            using(var cn = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand("UPDATE Users SET Name = @N, Surname = @S, Email = @E, PhoneNr = @P WHERE ID = @id", cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@N", name);
                cmd.Parameters.AddWithValue("@S", surname);
                cmd.Parameters.AddWithValue("@E", email);
                cmd.Parameters.AddWithValue("@P", phone);
                cmd.Parameters.AddWithValue("@id", ID);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        //TODO: logic for verifying changes
        public bool ChangeUserInfo(User user, string name, string surname, string email)
        {
            user.Name = name;
            user.Surname = surname;
            user.Email = email;
            SaveChanges();
            return true;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void AddHistoryRecord(User reader, Book book)
        {
            Context.ReadingHistory.Add(new ReadingHistory(book, reader, book.IssueDate, book.ReturnDate));
            SaveChanges();
        }
    }
}
