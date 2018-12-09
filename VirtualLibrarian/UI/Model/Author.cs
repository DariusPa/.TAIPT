using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using VirtualLibrarian.Data;

namespace VirtualLibrarian.Model
{
    public class Author
    {
        [Key]
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public Author()
        {
            Books = new HashSet<Book>();
        }

        public Author(string name, string surname, string country, string description="") : this()
        {
            Name = name;
            Surname = surname;
            Country = country;
            Description = description;
        }
    }
}