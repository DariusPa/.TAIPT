using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualLibrarian.Data;
using VirtualLibrarian.Model;

namespace VirtualLibrarian
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            LibraryData.Instance.Init("\\JSON\\books.json", "\\JSON\\users.json","\\JSON\\authors.json");
            LibraryData.Instance.LoadData();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FirstPage());
            //Application.Run(new UI(new User { Name = "a", Surname = "s", Email = "a" }));
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            LibraryData.Instance.SerializeData();
        }
    }
}
