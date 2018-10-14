using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian.Model
{
    public interface IBookModel
    {
        string Title { get; set; }
        string Author { get; set; }
        string Publisher { get; set; }
        string ISBN { get; set; }
        string Description { get; set; }
        int ID { get; set; }
        BookGenre Genre { get; set; }
        Status Status { get; set; }
        int ReaderID { get; set; }

        void Issue(IUserModel reader);
        void Return();

    }
}
