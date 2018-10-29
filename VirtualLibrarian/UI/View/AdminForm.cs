using System;
using System.Collections.Generic;
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
        private BindingSource authorSource;

        public event NewBookEventHandler NewBook;
        public event EventHandler AddAuthor;


        public AdminForm(AdministratorPresenter presenter)
        {

            InitializeComponent();
            this.presenter = presenter;
            presenter.BarcodeGenerated += ShowBarcode;
            authorSource = new BindingSource();
            authorSource.DataSource = LibraryDataIO.Instance.Authors;
            authorListBox.DataSource = authorSource;
            authorListBox.DisplayMember = StringConstants.fullNameString;
            genreBox.DataSource = Enum.GetValues(typeof(BookGenre));
        }

        private void OnSaveBook(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(titleBox.Text) && !string.IsNullOrWhiteSpace(isbnBox.Text)
                && !string.IsNullOrWhiteSpace(publisherBox.Text) && !string.IsNullOrWhiteSpace(authorListBox.Text)
                && !string.IsNullOrWhiteSpace(genreBox.Text))
            {
                BookGenre genres = new BookGenre();
                List<int> authors = new List<int>();

                foreach (var genre in genreBox.CheckedItems)
                {
                    genres = genres | (BookGenre)Enum.Parse(typeof(BookGenre), genre.ToString());
                }

                foreach (Author author in authorListBox.SelectedItems)
                {
                    authors.Add(author.ID);
                }
                Book = new Book(title: titleBox.Text, isbn: isbnBox.Text, authors: authors, 
                                    publisher: publisherBox.Text, genre: genres, description: descriptionBox.Text);

                NewBook?.Invoke(this, new BookRelatedEventArgs { Book = Book });

            }
            else
            {
                MessageBox.Show(StringConstants.missingInfo);
            }
            AutomaticFormPosition.SaveFormStatus(this);
        }

        private void ShowBarcode(object sender, BarcodeGeneratedEventArgs e)
        {
            barcodeBox.Image = e.Barcode;
            barcodeBox.Show();
        }


        private void AdminForm_Load(object sender, EventArgs e)
        {
            AutomaticFormPosition.LoadAutoPosition(this);
            authorListBox.ClearSelected();
            genreBox.ClearSelected();
            
        }

        public void RefreshAndClear()
        {
            
            foreach(var control in Controls)
            {
                if (control is TextBox || control is RichTextBox) ((TextBoxBase)control).Clear();
                if (control is ListBox) ((ListBox)control).ClearSelected();
                if (control is CheckedListBox)
                {
                    for(int i = 0; i< ((CheckedListBox)control).Items.Count; i++)
                    {
                        ((CheckedListBox)control).SetItemChecked(i, false);
                    }
                    
                }
            }
        }

        public void RefreshAuthors()
        {
            authorSource.ResetBindings(false);
        }

        public delegate void NewBookEventHandler(object sender, BookRelatedEventArgs e);

        private void newAuthor_Click(object sender, EventArgs e)
        {
            AddAuthor?.Invoke(sender, e);
        }
    }
}
