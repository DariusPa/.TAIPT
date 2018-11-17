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
using VirtualLibrarian.Helpers;
using VirtualLibrarian.Model;

namespace VirtualLibrarian.Data
{
    public sealed class LibraryDataIO: ILibraryData
    {
        public string ResourcePath { get; set; }
        public string DataDirPath { get; set; }
        private string bookPath;
        private string usersPath;
        private string authorsPath;
        public string FacesPath { get; set; }
        public string FaceLabelsPath { get; set; }
        private JsonSerializerSettings settings;

        private static readonly Lazy<LibraryDataIO> library = new Lazy<LibraryDataIO>(() => new LibraryDataIO());
        public List<IBookModel> Books { get; set; } = new List<IBookModel>();
        public List<IUserModel> Users { get; set; } = new List<IUserModel>();
        public List<Author> Authors { get; set; } = new List<Author>();
        public static LibraryDataIO Instance { get { return library.Value; } }

        public int PicturesPerUser { get; private set; }
        public ILogger Logger { get; set; }
        public ILogger UILogger { get; set; }


        private LibraryDataIO() { }

        public void Init(string directory, string bookPath, string usersPath, string authorsPath, string facesPath, string faceLabelsPath, int picturesPerUser=10)
        {
            Logger = new FileLogger(directory);
            UILogger = new UILogger();
            ResourcePath = directory + StringConstants.resourcePath;
            DataDirPath = directory + StringConstants.dataDirPath;
            this.bookPath = DataDirPath + bookPath;
            this.usersPath = DataDirPath + usersPath;
            this.authorsPath = DataDirPath + authorsPath;
            FacesPath = DataDirPath + facesPath;
            FaceLabelsPath = DataDirPath + faceLabelsPath;
            PicturesPerUser = picturesPerUser;
            settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        }

        public void SerializeAllData()
        {
            try
            {
                File.WriteAllText(authorsPath, JsonConvert.SerializeObject(Authors, Formatting.Indented, settings));
                File.WriteAllText(bookPath, JsonConvert.SerializeObject(Books, Formatting.Indented, settings));
                File.WriteAllText(usersPath, JsonConvert.SerializeObject(Users, Formatting.Indented, settings));
            }
            catch (Exception e)
            {
                Logger.LogException(e);
                UILogger.LogError(StringConstants.serealizationError);
            }
        }

        private void SerializeAuthors()
        {
            SerializeData(authorsPath, Authors);
        }

        private void SerializeBooks()
        {
            SerializeData(bookPath, Books);
        }

        private void SerializeUsers()
        {
             SerializeData(usersPath, Users);
        }

        private void SerializeData<T>(string filePath, T data)
        {
            try
            {
                new Thread(() => File.WriteAllText(filePath, JsonConvert.SerializeObject(data, Formatting.Indented, settings))).Start();
            }
            catch (Exception e)
            {
                Logger.LogException(e);
            }
        }

        private T DeserializeData<T>(string filePath, string warning)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath), settings);
            }
            catch (Exception e)
            {
                Logger.LogException(e);
                UILogger.LogWarning(warning);
                return default(T);
            }
        }

        public void LoadData()
        {
            try
            {
                if (!File.Exists(FaceLabelsPath))
                    File.Create(FaceLabelsPath).Dispose(); 
            }
            catch
            {
                Logger.LogError("Failed to open/create face labels file.");
                UILogger.LogError(StringConstants.loadError);
                Environment.Exit(0);
            }

            Users = DeserializeData<List<IUserModel>>(usersPath, StringConstants.noUsersWarning) ?? new List<IUserModel>();
            Books = DeserializeData<List<IBookModel>>(bookPath,StringConstants.noBooksWarning) ?? new List<IBookModel>();
            Authors = DeserializeData<List<Author>>(authorsPath,StringConstants.noAuthorsWarning) ?? new List<Author>();
        }


        public void AddNewFace(Image<Gray, byte> face,string label, int faceCount)
        {
            try
            {
                face.Save($"{FacesPath}\\{faceCount}.bmp");
                File.AppendAllText(FaceLabelsPath, label + "%");
            }
            catch (Exception e)
            {
                Logger.LogException(e);
                UILogger.LogError(StringConstants.saveFaceErrror);
            }

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

        //TODO: logic for verifying changes
        public bool ChangeUserInfo(IUserModel user, string name, string surname, string email)
        {
            user.Name = name;
            user.Surname = surname;
            user.Email = email;
            SerializeUsers();
            return true;
        }




    }
}
