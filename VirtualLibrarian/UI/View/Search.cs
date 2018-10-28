using System;
using System.Windows.Forms;
using VirtualLibrarian.Helpers;
using VirtualLibrarian.BusinessLogic;

namespace VirtualLibrarian
{
    public partial class Search : UserControl
    {
        private static Search _instance;
        public DataGridView libraryGrid
        {
            get { return libraryBooksGrid; }
        }
        public TextBox searchText { get { return searchBox; } }

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
