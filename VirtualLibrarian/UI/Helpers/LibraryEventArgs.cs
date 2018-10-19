using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrarian.Model;

namespace VirtualLibrarian.Helpers
{
    public class BookRelatedEventArgs : EventArgs
    {
        public IBookModel Book { get; set; }
    }
}
