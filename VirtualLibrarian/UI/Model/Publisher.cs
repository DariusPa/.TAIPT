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
    public class Publisher
    {
        [Key]
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public Publisher(string name, string country, string description = "") : base()
        {
            Name = name;
            Country = country;
            Description = description;
        }
    }
}
