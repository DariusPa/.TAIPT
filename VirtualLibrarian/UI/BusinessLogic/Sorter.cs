using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrarian.Model;

namespace VirtualLibrarian
{

    class BookComparer : IComparer<Book>
    {
        // The field to compare.
        public enum CompareField
        {
            Title,
            Publisher,
        }
        public CompareField SortBy = CompareField.Title;

        public int Compare(Book x, Book y)
        {
            switch (SortBy)
            {
                case CompareField.Publisher:
                    return x.Publisher.ID.CompareTo(y.Publisher.ID);
                default:
                    return x.Title.CompareTo(y.Title);

            }
        }
    }

    public class Sorter
    {


        public void SortBooks(Book[] books, string sortBy)
        {
            if (books == null) return;

            // Make the appropriate comparer.
            BookComparer sbc = new BookComparer();
            switch (sortBy.ToLower())
            {
                case "title":
                    sbc.SortBy = BookComparer.CompareField.Title;
                    break;
                case "publisher":
                    sbc.SortBy = BookComparer.CompareField.Publisher;
                    break;
                default:
                    throw new ArgumentException("Unknown sortBy argument", "sortBy");
            }

            // Sort.
            Array.Sort(books, sbc);
        }
    }
}