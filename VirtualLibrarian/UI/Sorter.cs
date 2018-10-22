using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrarian.Model;

namespace VirtualLibrarian
{

    class SmartCarComparer : IComparer<Book>
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
                case CompareField.Author:
                    return x.Author.CompareTo(y.Author);
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
            SmartCarComparer scc = new SmartCarComparer();
            switch (sortBy.ToLower())
            {
                case "Title":
                    scc.SortBy = SmartCarComparer.CompareField.Title;
                    break;
                case "Author":
                    scc.SortBy = SmartCarComparer.CompareField.Author;
                    break;
                case "Publisher":
                    scc.SortBy = SmartCarComparer.CompareField.Publisher;
                    break;
                default:
                    throw new ArgumentException("Unknown sortBy argument", "sortBy");
            }

            // Sort.
            Array.Sort(books, scc);
        }
    }
}