using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Data
{
    public class Library
    {
        private string dirPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Data\\JSON";

        private static Lazy<Library> library = new Lazy<Library>(() => new Library());
        public List<Book> books { get; private set; } = new List<Book>();
        public List<string> authors { get; private set; } = new List<string>();
        public List<User> readers { get; private set; } = new List<User>();
        private Library() { authors = new List<string>(); }

        public static Library Instance { get { return library.Value; } }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            //TODO logic for taken books here or in the book class
            books.Remove(book);
        }

        public void AddAuthor(string author)
        {
            authors.Add(author);
        }

        public void AddReader(User reader)
        {
            readers.Add(reader);
        }

        public void SerializeData()
        {
            File.WriteAllText(dirPath + "\\books.json", JsonConvert.SerializeObject(books));
            File.WriteAllText(dirPath + "\\authors.json", JsonConvert.SerializeObject(authors));
            File.WriteAllText(dirPath + "\\readers.json", JsonConvert.SerializeObject(readers));
        }

        public void LoadData()
        {
            try
            {
                books = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(dirPath + "\\books.json"));
                authors = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(dirPath + "\\authors.json"));
                readers = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(dirPath + "\\readers.json"));
            }
            catch (Exception e)
            {
                //TODO: handle properly
                Console.Write(e.Message);
            }
        }

        public bool IssueBookToReader(User reader, Book book)
        {
            if (book.Status == Status.Available)
            {
                book.Issue(reader);
                reader.TakeBook(book);
                return true;
            }
            else return false;
        }

        public bool ReturnBook(User reader, Book book)
        {
            if (reader.Readings.Contains(book.ID) && book.Reader == reader.ID)
            {
                book.Return();
                reader.ReturnBook(book);
                return true;
            }
            else return false;
        }



    }
}
