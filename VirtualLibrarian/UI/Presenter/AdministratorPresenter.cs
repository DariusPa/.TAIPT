using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualLibrarian.BusinessLogic;
using VirtualLibrarian.Data;
using VirtualLibrarian.Helpers;
using VirtualLibrarian.Model;
using VirtualLibrarian.View;
using ZXing;
using static VirtualLibrarian.AdminForm;

namespace VirtualLibrarian.Presenter
{
    public class AdministratorPresenter
    {
        private FirstPage firstPage;
        private AdminForm adminForm;
        private BarcodeGenerator barcodeGenerator;
        private NewAuthorForm authorForm;
        public IBookModel Book;

        public event BarcodeGeneratedEventHandler BarcodeGenerated;
        

        public AdministratorPresenter(FirstPage firstPage)
        {
            barcodeGenerator = new BarcodeGenerator(LibraryDataIO.Instance.DirectoryPath + "\\Barcodes");
           
            this.firstPage = firstPage;
            firstPage.Administrate += ShowAdminForm;

        }

        private void ShowAdminForm(object sender, EventArgs e)
        {
            adminForm = new AdminForm(this);
            adminForm.NewBook += AddNewBook;
            adminForm.FormClosing += ShowFirstPage;
            adminForm.AddAuthor += ShowAuthorForm;
            adminForm.Show();
        }

        private void AddNewBook(object sender, BookRelatedEventArgs e)
        {
            Book = e.Book;
            LibraryDataIO.Instance.AddBook(Book);

            var barcode = barcodeGenerator.GenerateBarcode(Book.ID);
            BarcodeGenerated?.Invoke(this, new BarcodeGeneratedEventArgs { Barcode = barcode });
            adminForm.RefreshAndClear();

        }

        private void ShowFirstPage(object sender, EventArgs e)
        {
            firstPage.Show(); 
        }

        private void ShowAuthorForm(object sender, EventArgs e)
        {
            authorForm = new NewAuthorForm();
            authorForm.NewAuthor += AddNewAuthor;
            authorForm.Show();

        }

        private void AddNewAuthor(object sender, BookRelatedEventArgs e)
        {
            if (LibraryDataIO.Instance.Authors.FindIndex(author => author.FullName.Equals(e.Author.FullName))<0)
            {
                LibraryDataIO.Instance.AddAuthor(e.Author);
                authorForm?.Close();
                adminForm.RefreshAuthors();

            } else
            {
                MessageBox.Show("Author already exists!");
            }

        }

        public class BarcodeGeneratedEventArgs : EventArgs
        {
            public Image Barcode { get; set; }
        }



        public delegate void BarcodeGeneratedEventHandler(object sender, BarcodeGeneratedEventArgs e);

    }
}
