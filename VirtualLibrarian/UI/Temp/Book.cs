using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian.Temp
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }

        public static List<Book> GetAllBooks()
        {
            return new List<Book>()
            {
                new Book { ID = 1, Title = "Juror", AuthorID = 1},
                new Book { ID = 2, Title = "Target: Alex Cross", AuthorID = 1},
                new Book { ID = 3, Title = "Max Einstein: The Genius Experiment", AuthorID = 1},
                new Book { ID = 4, Title = "My Life", AuthorID = 2},
                new Book { ID = 5, Title = "Jim Marshall: Jazz Festival", AuthorID = 2},
                new Book { ID = 6, Title = "The President Is Missing", AuthorID = 2},
                new Book { ID = 7, Title = "Harry Potter Complete Book Series", AuthorID = 3},
                new Book { ID = 8, Title = "Fantastic Beasts", AuthorID = 3},
                new Book { ID = 9, Title = "Harry Potter", AuthorID = 3},
                new Book { ID = 10, Title = "The Reckoning", AuthorID = 4},
                new Book { ID = 11, Title = "Camino Island", AuthorID = 4},
                new Book { ID = 12, Title = "The Whistler", AuthorID = 4},
            };
        }
    }
}
