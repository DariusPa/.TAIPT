using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrarian.Model;

namespace VirtualLibrarian.Data
{
    interface ILibraryData
    {
        List<IBookModel> Books { get; set; }
        List<IUserModel> Users { get; set; }
        List<Author> Authors { get; set; }

        void AddBook(IBookModel book);
        void RemoveBook(IBookModel book);
        void AddUser(IUserModel user);
        void RemoveUser(IUserModel user);
        void AddAuthor(Author author);
        void RemoveAuthor(Author author);
    }
}
