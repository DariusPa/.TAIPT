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
        List<Author> Authors { get; set; }
        string Publisher { get; set; }
        string ISBN { get; set; }
        string Description { get; set; }
        int ID { get; }
        BookGenre Genre { get; set; }
        Status Status { get; }
        int ReaderID { get; }

        void Issue(IUserModel reader);
        void Return();

    }

}
