using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VirtualLibrarian.Data;

namespace VirtualLibrarian.Model
{
    public class ReadingHistory
    {
        [Key]
        public int ID { get; private set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }

        public ReadingHistory()
        {
        }

        public ReadingHistory(Book book, User reader, DateTime? issueDate, DateTime? returnDate)
        {
            Book = book;
            User = reader;
            IssueDate = issueDate;
            ReturnDate = returnDate;
        }
    }
}
