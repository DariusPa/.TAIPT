using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian.Model
{
    class User : IUserModel
    {
        private static int count = 0;
        public int ID { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }
        public List<int> ReadingsID { get; set; } = new List<int>();

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

        public void TakeBook(IBookModel book)
        {
            ReadingsID.Add(book.ID);
        }

        public void ReturnBook(IBookModel book)
        {
            ReadingsID.Remove(book.ID);
        }
    }
}
