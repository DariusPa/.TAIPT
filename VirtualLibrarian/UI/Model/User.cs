using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VirtualLibrarian.Model
{
    public class User : IUserModel
    {
        private static int count;
        [JsonProperty]
        public int ID { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }
        [JsonProperty]
        public List<int> TakenBooks { get; private set; } = new List<int>();
        public List<ReadingHistory> History { get; private set; } = new List<ReadingHistory>();

        public User()
        {
            ID = Interlocked.Increment(ref count);
        }

        public User(string name, string surname, string email) : this()
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public void TakeBook(IBookModel book)
        {
            TakenBooks.Add(book.ID);
        }

        public void ReturnBook(IBookModel book)
        {
            TakenBooks.Remove(book.ID);
            History.Add(new ReadingHistory(book.ID, book.IssueDate,book.ReturnDate));
        }
    }
}
