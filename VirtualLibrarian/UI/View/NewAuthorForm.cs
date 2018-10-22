using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualLibrarian.Helpers;
using VirtualLibrarian.Model;

namespace VirtualLibrarian.View
{
    public partial class NewAuthorForm : Form
    {
        public event NewAuthorEventHandler NewAuthor;

        public NewAuthorForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(authorNameBox.Text) && !string.IsNullOrWhiteSpace(authorSurnameBox.Text))
            {
                NewAuthor?.Invoke(this, new BookRelatedEventArgs { Author = new Author(authorNameBox.Text, authorSurnameBox.Text) });
            }
            else
            {
                MessageBox.Show("Information missing!");
            }

        }

        public delegate void NewAuthorEventHandler(object sender, BookRelatedEventArgs e);
    }
}
