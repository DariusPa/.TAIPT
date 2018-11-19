using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrarian.Model;

namespace VirtualLibrarian.Data
{
    public static class LibraryManager
    {
        /*Reader cannot keep more than 5 books*/
        private static int maxBookAmount = 5;

        public static void IssueBookToReader(IUserModel reader, IBookModel book)
        {
            book.Issue(reader);
            reader.TakeBook(book);
            LibraryDataIO.Instance.SerializeAllData();
        }

        public static void ReturnBook(IUserModel reader, IBookModel book)
        {
            book.Return();
            reader.ReturnBook(book);
            LibraryDataIO.Instance.SerializeAllData();
        }

        public static bool  ValidateIssuing(IUserModel reader, IBookModel book)
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

        public static bool ValidateReturning(IUserModel reader, IBookModel book)
        {
            if (reader != null && reader.TakenBooks.Contains(book.ID) && book?.ReaderID == reader.ID)
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
