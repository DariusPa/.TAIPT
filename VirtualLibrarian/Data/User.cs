using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class User
    {
        private static int count = 0;
        public int ID { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }
        public List<int> Readings { get; set; } = new List<int>();

        public User()
        {
            ID = ++count;
        }

        public User(string name, string surname, string email) : this()
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public void TakeBook(Book book)
        {
             Readings.Add(book.ID);
        }


    }
}
