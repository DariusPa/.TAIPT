using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian.Model
{
    public struct ReadingHistory
    {
        public int BookID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public ReadingHistory(int id, DateTime issueDate, DateTime returnDate)
        {
            BookID = id;
            IssueDate = issueDate;
            ReturnDate = returnDate;
        }
    }
}
