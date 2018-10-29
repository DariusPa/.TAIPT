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
        public static bool IssueBookToReader(IUserModel reader, IBookModel book)
        {
            if (book.Status == Status.Available)
            {
                book.Issue(reader);
                reader.TakeBook(book);
                LibraryDataIO.Instance.SerializeData();
                return true;
            }
            else return false;
        }

        public static bool ReturnBook(IUserModel reader, IBookModel book)
        {
            if (reader.TakenBooks.Contains(book.ID) && book.ReaderID == reader.ID)
            {
                book.Return();
                reader.ReturnBook(book);
                LibraryDataIO.Instance.SerializeData();
                return true;
            }
            else return false;
        }
    }
}
