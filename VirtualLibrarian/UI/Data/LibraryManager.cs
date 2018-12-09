using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrarian.BusinessLogic;
using VirtualLibrarian.Model;

namespace VirtualLibrarian.Data
{
    public static class LibraryManager
    {
        /*Reader cannot keep more than 5 books*/
        private static int maxBookAmount = 5;


        public static void IssueBookToReader(User reader, Book book)
        {
            book.Issue(reader);
            reader.TakeBook(book);
            LibraryDataIO.Instance.SaveChanges();
        }

        public static void ReturnBook(User reader, Book book)
        {
            book.Return();
            reader.ReturnBook(book);
            LibraryDataIO.Instance.AddHistoryRecord(reader, book);
        }

        public static bool  ValidateIssuing(User reader, Book book)
        {
            if(book?.Status == Status.Available && reader?.TakenBooks.Count < maxBookAmount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidateReturning(User  reader, Book book)
        {
            if (reader != null && reader.TakenBooks.Contains(book) && book?.User == reader)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
