using Emgu.CV;
using Emgu.CV.Structure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VirtualLibrarian.Model;

namespace VirtualLibrarian.Data
{
    public sealed class LibraryDataIO: ILibraryData
    {
        public string ResourcePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources";
        public string DirectoryPath { get; set; } = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Data";
        private string bookPath;
        private string usersPath;
        private string authorsPath;
        public string FacesPath { get; set; }
        public string FaceLabelsPath { get; set; }

        private static readonly Lazy<LibraryDataIO> library = new Lazy<LibraryDataIO>(() => new LibraryDataIO());
        public List<IBookModel> Books { get; set; } = new List<IBookModel>();
        public List<IUserModel> Users { get; set; } = new List<IUserModel>();
        public List<Author> Authors { get; set; } = new List<Author>();
        public static LibraryDataIO Instance { get { return library.Value; } }

        public int PicturesPerUser { get; private set; }

        private LibraryDataIO() { }

        public void Init(string bookPath, string usersPath, string authorsPath, string facesPath, string faceLabelsPath, int picturesPerUser=10)
        {
            this.bookPath = bookPath;
            this.usersPath = usersPath;
            this.authorsPath = authorsPath;
            FacesPath = DirectoryPath + facesPath;
            FaceLabelsPath = DirectoryPath + faceLabelsPath;
            PicturesPerUser = picturesPerUser;
        }

        public void SerializeData()
        {
            File.WriteAllText(DirectoryPath + authorsPath, JsonConvert.SerializeObject(Authors));
            File.WriteAllText(DirectoryPath + bookPath, JsonConvert.SerializeObject(Books, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
            }));
            File.WriteAllText(DirectoryPath + usersPath, JsonConvert.SerializeObject(Users, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
            }));
        }

        public void SerializeAuthors()
        {
            new Thread(() => File.WriteAllText(DirectoryPath + authorsPath, JsonConvert.SerializeObject(Authors))).Start();
        }

        public void SerializeBooks()
        {
            new Thread(()=>File.WriteAllText(DirectoryPath + bookPath, JsonConvert.SerializeObject(Books, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
            }))).Start();
        }

        public void SerializeUsers()
        {
            new Thread(()=>File.WriteAllText(DirectoryPath + usersPath, JsonConvert.SerializeObject(Users, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
            }))).Start();
        }

        public void LoadData()
        {
            try
            {
                if (!File.Exists(FaceLabelsPath))
                    File.Create(FaceLabelsPath);
            }
            catch
            {
                //TODO: handle properly
                Console.Write("Failed to open/create face labels file");
            }
            try
            {
                Authors = JsonConvert.DeserializeObject<List<Author>>(File.ReadAllText(DirectoryPath + authorsPath));
                Books = JsonConvert.DeserializeObject<List<IBookModel>>(File.ReadAllText(DirectoryPath + bookPath), new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
                Users = JsonConvert.DeserializeObject<List<IUserModel>>(File.ReadAllText(DirectoryPath + usersPath), new JsonSerializerSettings
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


        public void AddNewFace(Image<Gray, byte> face,string label, int faceCount)
        {
            face.Save($"{FacesPath}\\{faceCount}.bmp");
            File.AppendAllText(FaceLabelsPath, label + "%");
        }

        public void AddBook(IBookModel book)
        {
            Books.Add(book);
            SerializeBooks();
        }

        public void RemoveBook(IBookModel book)
        {
            //TODO logic for taken books here or in the book class
            Books.Remove(book);
            SerializeBooks();
        }

        public void AddUser(IUserModel user)
        {
            Users.Add(user);
            SerializeUsers();
        }

        public void RemoveUser(IUserModel user)
        {
            Users.Remove(user);
            SerializeUsers();
        }

        public void AddAuthor(Author author)
        {
            Authors.Add(author);
            SerializeAuthors();
        }

        public void RemoveAuthor(Author author)
        {
            Authors.Remove(author);
            SerializeAuthors();
        }

        public IUserModel FindUser(string label)
        {
            return Instance.Users.Find(x => x.ID == int.Parse(label));
        }

        public IBookModel FindBook(string label)
        {
            return Instance.Books.Find(x => x.ID == int.Parse(label));
        }




    }
}
