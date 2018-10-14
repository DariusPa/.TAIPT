using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian.Model
{
    class Book: IBookModel
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
    }

    public enum Status
    {
        Available,
        Reserved,
        Taken
    }
}
