using System;
using System.Windows.Forms;
using VirtualLibrarian.Data;
using VirtualLibrarian.Helpers;
using VirtualLibrarian.Model;
using VirtualLibrarian.Presenter;
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

        private void OnSaveBook(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(titleBox.Text) && !string.IsNullOrWhiteSpace(isbnBox.Text)
                && !string.IsNullOrWhiteSpace(publisherBox.Text) && !string.IsNullOrWhiteSpace(authorBox.Text)
                && !string.IsNullOrWhiteSpace(genreBox.Text))
            {
                BookGenre genres = new BookGenre();
                foreach (var genre in genreBox.CheckedItems)
                {
                    genres = genres | (BookGenre)Enum.Parse(typeof(BookGenre), genre.ToString());
                }

                Book = new Book{ Title = titleBox.Text, ISBN = isbnBox.Text,
                                 Publisher = publisherBox.Text, Author = authorBox.Text,
                                 Genre = genres, Description = descriptionBox.Text };

                NewBook?.Invoke(this, new BookRelatedEventArgs { Book = Book });

            }
            else
            {
                MessageBox.Show("Information missing.");
            }
        }

        private void ShowBarcode(object sender, BarcodeGeneratedEventArgs e)
        {
            barcodeBox.Image = e.Barcode;
            barcodeBox.Show();
        }


        private void AdminForm_Load(object sender, EventArgs e)
        {
            genreBox.DataSource = Enum.GetValues(typeof(BookGenre)); 

        }

        private void authorBox_Enter(object sender, EventArgs e)
        {
            authorBox.DataSource = LibraryData.Instance.Authors.ToArray();
        }

        public delegate void NewBookEventHandler(object sender, BookRelatedEventArgs e);
    }
}
