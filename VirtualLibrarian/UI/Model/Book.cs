using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian.Model
{
    class Book: IBookModel
    {
        private static int count;
        public string Title { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();
        public string Publisher { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public BookGenre Genre { get; set; }
        [JsonProperty]
        public int ID { get; }
        [JsonProperty]
        public Status Status { get; private set; }
        [JsonProperty]
        public int ReaderID { get; private set; }


        public Book()
        {
            ID = ++count;
            Status = Status.Available;
        }

        public Book(string title, List<Author> authors, string publisher, BookGenre genre, string isbn, string description = "") : this()
        {
            Title = title;
            Authors = authors;
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
