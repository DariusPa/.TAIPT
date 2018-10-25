using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrarian.Model;

namespace VirtualLibrarian
{

    class SmartBookComparer : IComparer<Book>
    {
        // The field to compare.
        public enum CompareField
        {
            Title,
            Author,
            Publisher,
        }
        public CompareField SortBy = CompareField.Title;

        public int Compare(Book x, Book y)
        {
            switch (SortBy)
            {
                case CompareField.Title:
                    return x.Title.CompareTo(y.Title);
                case CompareField.Publisher:
                    return x.Publisher.CompareTo(y.Publisher);
            }
            return x.Title.CompareTo(y.Title);
        }
    }

    public class Sorter
    {


        public void SortBooks(Book[] books, string sortBy)
        {
            if (books == null) return;

            // Make the appropriate comparer.
            SmartBookComparer sbc = new SmartBookComparer();
            switch (sortBy.ToLower())
            {
                case "title":
                    sbc.SortBy = SmartBookComparer.CompareField.Title;
                    break;
                case "author":
                    sbc.SortBy = SmartBookComparer.CompareField.Author;
                    break;
                case "publisher":
                    sbc.SortBy = SmartBookComparer.CompareField.Publisher;
                    break;
                default:
                    throw new ArgumentException("Unknown sortBy argument", "sortBy");
            }

            // Sort.
            Array.Sort(books, sbc);
        }
    }
}