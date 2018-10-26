using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualLibrarian.Data;
using VirtualLibrarian.Model;
using VirtualLibrarian.Helpers;

namespace VirtualLibrarian
{
    public partial class ReturnBook : UserControl
    {
        private static ReturnBook _instance;
        public event BookReturnEventHandler BookReturn;

        public DataGridView dataGridView
        {
            get { return bookListDataGrid; }
            set { bookListDataGrid = value; }
        }

        public static ReturnBook Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ReturnBook();
                return _instance;
            }
        }

        public ReturnBook()
        {
            InitializeComponent();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in bookListDataGrid.SelectedRows)
            {
                var temp = dataGridView.DataSource;
                var book = LibraryDataIO.Instance.Books.Find(x => x.ID == int.Parse(item.Cells[0].Value.ToString()));
                BookReturn?.Invoke(this, new BookRelatedEventArgs { Book = book });
            }
        }

        public delegate void BookReturnEventHandler(object sender, BookRelatedEventArgs e);

    }
}
