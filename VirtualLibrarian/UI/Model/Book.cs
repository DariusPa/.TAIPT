using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VirtualLibrarian.Data;

namespace VirtualLibrarian.Model
{
    public class Book:ICloneable
    {
        [Key]
        public int ID { get; private set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public BookGenre Genre { get; set; }
        public Status Status { get; private set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int LendingMonths { get; set; }
        public int Pages { get; set; }
        public int PublisherID { get; set; }
        public int? UserID { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<ReadingHistory> ReadingHistories { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual User User { get; private set; }



        public Book()
        {
            Authors = new HashSet<Author>();
            ReadingHistories = new HashSet<ReadingHistory>();
        }

        public Book(string title, List<Author> authors, Publisher publisher, BookGenre genre, string isbn, int pages, string description, int lendingMonths = 1) : this()
        {
            Title = title;
            foreach (var author in authors)
            {
                Authors.Add(author);
            }
            Publisher = publisher;
            ISBN = isbn;
            Description = description;
            Genre = genre;
            LendingMonths = lendingMonths;
            Pages = pages;
        }

        public void Issue(User reader)
        {
            Status = Status.Taken;
            User = reader;
            IssueDate = DateTime.Now;
            ReturnDate = IssueDate.Value.AddMonths(LendingMonths);
        }

        public void Return()
        {
            Status = Status.Available;
            User = null;
            ReturnDate = DateTime.Now;

        }

        public object Clone()
        {
            Book book = new Book();
            book.Title = Title;
            book.Authors = Authors;
            book.Publisher = Publisher;
            book.ISBN = ISBN;
            book.Description = Description;
            book.Genre = Genre;
            book.Pages = Pages;
            book.Status = Status.Available;
            return book;
        }
    }


}
