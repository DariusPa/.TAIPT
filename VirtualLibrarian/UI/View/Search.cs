using System;
using System.Windows.Forms;
using VirtualLibrarian.Helpers;
using VirtualLibrarian.BusinessLogic;

namespace VirtualLibrarian
{
    public partial class Search : UserControl
    {
        private static Search _instance;

        public static Search Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Search();
                return _instance;
            }
        }

        public Search()
        {
            InitializeComponent();
        }


    }
}
