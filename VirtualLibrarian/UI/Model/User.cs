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
    public class User
    {
        [Key]
        public int ID { get; private set; } 
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }

        public virtual ICollection<Book> TakenBooks { get; set; }
        public virtual ICollection<Face> Faces { get; set; }
        public virtual ICollection<ReadingHistory> ReadingHistories { get; set; }


        public User()
        {
            TakenBooks = new HashSet<Book>();
            Faces = new HashSet<Face>();
            ReadingHistories = new HashSet<ReadingHistory>();
        }

        public User(string name, string surname, string email) : this()
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public void TakeBook(Book book)
        {
            TakenBooks.Add(book);
        }

        public void ReturnBook(Book book)
        {
            TakenBooks.Remove(book);
        }
    }
}
