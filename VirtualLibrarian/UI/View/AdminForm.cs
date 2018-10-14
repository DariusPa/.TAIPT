using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VirtualLibrarian.Data;
using VirtualLibrarian.Model;
using VirtualLibrarian.Presenter;
using ZXing;
using static VirtualLibrarian.Presenter.AdministratorPresenter;

namespace VirtualLibrarian
{
    public partial class AdminForm : Form
    {
        public IBookModel Book { get; set; }
        private AdministratorPresenter presenter;

        public event NewBookEventHandler NewBook;


        public AdminForm(AdministratorPresenter presenter)
        {
            InitializeComponent();
            this.presenter = presenter;
            presenter.BarcodeGenerated += ShowBarcode;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(titleBox.Text) && !string.IsNullOrWhiteSpace(isbnBox.Text)
                && !string.IsNullOrWhiteSpace(publisherBox.Text) && !string.IsNullOrWhiteSpace(authorBox.Text)
                && !string.IsNullOrWhiteSpace(genreBox.Text))
            {
                Book = new Book{ Title = titleBox.Text, ISBN = isbnBox.Text,
                                 Publisher = publisherBox.Text, Author = authorBox.Text,
                                 Genre = (BookGenre)Enum.Parse(typeof(BookGenre), genreBox.Text), Description = descriptionBox.Text };

                NewBook?.Invoke(this, new NewBookEventArgs { PendingBook = Book });

            }
        }

        private void ShowBarcode(object sender, BarcodeGeneratedEventArgs e)
        {
            barcodeBox.Image = e.Barcode;
            barcodeBox.Show();
        }


        private void AdminForm_Load(object sender, EventArgs e)
        {
            genreBox.DataSource = Enum.GetValues(typeof (BookGenre));
            
        }

        private void authorBox_Enter(object sender, EventArgs e)
        {
            authorBox.DataSource = LibraryData.Instance.Authors.ToArray();
        }

        public class NewBookEventArgs : EventArgs
        {
            public IBookModel PendingBook { get; set; }
        }

        public delegate void NewBookEventHandler(object sender, NewBookEventArgs e);
    }
}
