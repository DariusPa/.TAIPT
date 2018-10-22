using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian.Model
{
    public class Book: IBookModel , ICloneable
    {
        public static int count;
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
        public BookGenre Genre { get; set; }
        public Status Status { get; set; }
        public int ReaderID { get; set; }


        public Book()
        {
            ID = ++count;
            Status = Status.Available;
        }

        public Book(string title, string author, string publisher, BookGenre genre, string isbn, string description = "") : this()
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            ISBN = isbn;
            Description = description;
            Genre = genre;
        }
        public Book(string title, string author, string publisher)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
        }

        public void Issue(IUserModel reader)
        {
            Status = Status.Taken;
            ReaderID = reader.ID;
        }

        public void Return()
        {
            Status = Status.Available;
            ReaderID = -1;
        }

        public object Clone()
        {
            Book book = new Book();
            book.Title = Title;
            book.Author = Author;
            book.Publisher = Publisher;
            book.ISBN = ISBN;
            book.Description = Description;
            book.Genre = Genre;
            book.Status = Status.Available;
            return book;
        }
    }

    public enum Status
    {
        Available,
        Reserved,
        Taken
    }
}
