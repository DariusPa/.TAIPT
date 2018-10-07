using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;

namespace VirtualLibrarian
{
    public partial class ReturnBook : UserControl
    {
        private static ReturnBook _instance;
        public User reader;
        public DataGridView dataGridView
        {
            get { return dataGridView1; }
            set { dataGridView1 = value; }
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
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                var temp = dataGridView.DataSource;
                var book = Library.Instance.books.Find(x => x.ID == int.Parse(item.Cells[0].Value.ToString()));
                if (Library.Instance.ReturnBook(reader, book))
                {
                    MessageBox.Show("OK");
                }
                else
                {
                    MessageBox.Show("Error occured");
                    break;
                }
            }
        }
    }
}
