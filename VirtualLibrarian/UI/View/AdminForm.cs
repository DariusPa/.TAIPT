using System;
using System.Collections.Generic;
using System.Linq;
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
        public Book Book { get; set; }
        private AdministratorPresenter presenter;
        private BindingSource authorSource;

        public event NewBookEventHandler NewBook;
        public event EventHandler AddAuthor;


        public AdminForm(AdministratorPresenter presenter)
        {

            InitializeComponent();
            this.presenter = presenter;
            RefreshAuthors();
            authorListBox.DisplayMember = "Name";
            genreBox.DataSource = Enum.GetValues(typeof(BookGenre));
            publisherListBox.DataSource = LibraryDataIO.Instance.Context.Publishers.ToList();
            publisherListBox.DisplayMember = "Name";
        }

        private void OnSaveBook(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(titleBox.Text) && !string.IsNullOrWhiteSpace(isbnBox.Text)
                && !string.IsNullOrWhiteSpace(publisherListBox.Text) && !string.IsNullOrWhiteSpace(authorListBox.Text)
                && !string.IsNullOrWhiteSpace(genreBox.Text) && !string.IsNullOrWhiteSpace(qtyBox.Text) && !string.IsNullOrWhiteSpace(pagesBox.Text))
            {
                BookGenre genres = new BookGenre();
                List<Author> authors = new List<Author>();
                int.TryParse(qtyBox.Text, out int qty);
                int.TryParse(pagesBox.Text, out int pages);

                foreach (var genre in genreBox.CheckedItems)
                {
                    genres = genres | (BookGenre)Enum.Parse(typeof(BookGenre), genre.ToString());
                }

                foreach (Author author in authorListBox.SelectedItems)
                {
                    authors.Add(author);
                }

                var publisher = ((Publisher)publisherListBox.SelectedItem);
                for (int i = 0; i < qty; i++)
                {
                    Book = new Book(title: titleBox.Text, isbn: isbnBox.Text, authors: authors,
                                        publisher: publisher, genre: genres, description: descriptionBox.Text, pages: pages);

                    NewBook?.Invoke(this, new BookRelatedEventArgs { Book = Book });
                }
                MessageBox.Show(StringConstants.BookRegistered(titleBox.Text, isbnBox.Text));
                RefreshAndClear();

            }
            else
            {
                MessageBox.Show(StringConstants.missingInfo);
            }
            AutomaticFormPosition.SaveFormStatus(this);
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
                if (control is TextBox) ((TextBox)control).Clear();
                if (control is RichTextBox) ((RichTextBox)control).Clear();
                if (control is ListBox)
                    ((ListBox)control).ClearSelected();
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
            authorListBox.DataSource = LibraryDataIO.Instance.Context.Authors.ToList();
        }

        public delegate void NewBookEventHandler(object sender, BookRelatedEventArgs e);

        private void newAuthor_Click(object sender, EventArgs e)
        {
            AddAuthor?.Invoke(sender, e);
        }

        private void qtyBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(qtyBox.Text, "[^0-9]"))
            {
                qtyBox.Text = qtyBox.Text.Remove(qtyBox.Text.Length - 1);
                qtyBox.SelectionStart = qtyBox.Text.Length;
            }
        }
    }
}
