using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian.Model
{
    public interface IUserModel
    {
        int ID { get; }
        string Name { get; set; }
        string Surname { get; set; }
        string Email { get; set; }
        string PhoneNr { get; set; }
        List<int> ReadingsID { get; set; }

        void TakeBook(IBookModel book);
        void ReturnBook(IBookModel book);
    }
}
