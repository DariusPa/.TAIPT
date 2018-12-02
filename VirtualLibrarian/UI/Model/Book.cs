using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VirtualLibrarian.Model
{
    public class Book: IBookModel , ICloneable
    {
        private static int count;
        public string Title { get; set; }
        public List<int> AuthorID { get; set; } = new List<int>();
        public int PublisherID { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public BookGenre Genre { get; set; }
        [JsonProperty]
        public int ID { get; }
        [JsonProperty]
        public Status Status { get; private set; }
        [JsonProperty]
        public int ReaderID { get; private set; }
        public DateTime IssueDate {get;set; }
        public DateTime ReturnDate { get; set; }
        public int LendingMonths { get; set; }



        public Book()
        {
            ID = Interlocked.Increment(ref count);
            Status = Status.Available;
        }

        public Book(string title, List<int> authorID, int publisherID, BookGenre genre, string isbn, string description, int lendingMonths = 1) : this()
        {
            Title = title;
            AuthorID = authorID;
            PublisherID = publisherID;
            ISBN = isbn;
            Description = description;
            Genre = genre;
            LendingMonths = lendingMonths;
        }

        public void Issue(IUserModel reader)
        {
            Status = Status.Taken;
            ReaderID = reader.ID;
            IssueDate = DateTime.Now;
            ReturnDate = IssueDate.AddMonths(LendingMonths);
        }

        public void Return()
        {
            Status = Status.Available;
            ReaderID = -1;
            ReturnDate = DateTime.Now;

        }

        public object Clone()
        {
            Book book = new Book();
            book.Title = Title;
            book.AuthorID = AuthorID;
            book.PublisherID = PublisherID;
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
