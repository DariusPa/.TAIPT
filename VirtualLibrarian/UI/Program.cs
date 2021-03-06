﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualLibrarian.Data;
using VirtualLibrarian.Helpers;
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
            LibraryDataIO.Instance.Init(StringConstants.directory,@"JSON\books.json", @"JSON\users.json", @"JSON\authors.json", 
                                            @"Faces", @"Faces\TrainedLabels.txt");
            LibraryDataIO.Instance.LoadData();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FirstPage());
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            LibraryDataIO.Instance.SerializeAllData();
        }
    }
}
