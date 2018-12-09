using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian.Model
{
    public class Face
    {
        [Key]
        public string Path { get; set; }
        public int UserID { get; set; }

        public virtual User User { get; set; }


        public Face() { }

        public Face(User user, string path)
        {
            User = user;
            Path = path;
        }
    }
}
