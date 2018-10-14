using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrarian.Model;

namespace VirtualLibrarian.Data
{
    class LibraryData: ILibraryData
    {
        public string directoryPath { get; set; } = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Data";
        private string bookPath;
        private string usersPath;
        private string authorsPath;

        private static Lazy<LibraryData> library = new Lazy<LibraryData>(() => new LibraryData());
        public List<IBookModel> Books { get; set; } = new List<IBookModel>();
        public List<IUserModel> Users { get; set; } = new List<IUserModel>();
        public List<string> Authors { get; set; } = new List<string>();
        public static LibraryData Instance { get { return library.Value; } }

        private LibraryData() { }

        public void Init(string bookPath, string usersPath, string authorsPath)
        {
            this.bookPath = bookPath;
            this.usersPath = usersPath;
            this.authorsPath = authorsPath;
        }

        public void SerializeData()
        {
            File.WriteAllText(directoryPath + authorsPath, JsonConvert.SerializeObject(Authors));
            File.WriteAllText(directoryPath + bookPath, JsonConvert.SerializeObject(Books, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
            }));
            File.WriteAllText(directoryPath + usersPath, JsonConvert.SerializeObject(Users, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
            }));
        }

        public void LoadData()
        {


            try
            {
                Authors = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(directoryPath + authorsPath));
                Books = JsonConvert.DeserializeObject<List<IBookModel>>(File.ReadAllText(directoryPath + bookPath), new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
                Users = JsonConvert.DeserializeObject<List<IUserModel>>(File.ReadAllText(directoryPath + usersPath), new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                }); 
            }
            catch (Exception e)
            {
                //TODO: handle properly
                Console.Write(e.Message);
            }
        }

        public void AddBook(IBookModel book)
        {
            Books.Add(book);
        }

        public void RemoveBook(IBookModel book)
        {
            //TODO logic for taken books here or in the book class
            Books.Remove(book);
        }

        public void AddUser(IUserModel user)
        {
            Users.Add(user);
        }

        public void RemoveUser(IUserModel user)
        {
            Users.Remove(user);
        }

        public void AddAuthor(string author)
        {
            Authors.Add(author);
        }

        public List<IBookModel> GetBooks()
        {
            return Books;
        }

        public List<IUserModel> GetUsers()
        {
            return Users;
        }

        public IUserModel FindUser(string label)
        {
            return Instance.Users.Find(x => x.ID == int.Parse(label));
        }

        public IBookModel FindBook(string label)
        {
            return Instance.Books.Find(x => x.ID == int.Parse(label));
        }


        //TODO: move to a separate class
        public bool IssueBookToReader(IUserModel reader, IBookModel book)
        {
            if (book.Status == Status.Available)
            {
                book.Issue(reader);
                reader.TakeBook(book);
                return true;
            }
            else return false;
        }

        public bool ReturnBook(IUserModel reader, IBookModel book)
        {
            if (reader.ReadingsID.Contains(book.ID) && book.ReaderID == reader.ID)
            {
                book.Return();
                reader.ReturnBook(book);
                return true;
            }
            else return false;
        }
    }
}
