using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian.Temp
{
    public class Author
    {
        public int ID { get; set; }
        public String Name { get; set; }

        public static List<Author> GetAllAuthors()
        {
            return new List<Author>()
            {
                new Author { ID = 1, Name = "James Patterson"},
                new Author { ID = 2, Name = "Bill Clinton"},
                new Author { ID = 3, Name = "J. K. Rowling"},
                new Author { ID = 4, Name = "John Grisham"},
            };
        }
    }
}
