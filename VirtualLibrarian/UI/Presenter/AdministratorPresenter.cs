using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrarian.BusinessLogic;
using VirtualLibrarian.Data;
using VirtualLibrarian.Model;
using ZXing;
using static VirtualLibrarian.AdminForm;

namespace VirtualLibrarian.Presenter
{
    public class AdministratorPresenter
    {
        private FirstPage firstPage;
        private AdminForm adminForm;
        private UI UI;
        private BarcodeGenerator barcodeGenerator;
        public IBookModel Book;

        public event BarcodeGeneratedEventHandler BarcodeGenerated;
        

        public AdministratorPresenter(FirstPage firstPage)
        {
            barcodeGenerator = new BarcodeGenerator(LibraryData.Instance.directoryPath + "\\Barcodes");
            this.firstPage = firstPage;
            firstPage.Administrate += ShowAdminForm;
            adminForm = new AdminForm(this);
            adminForm.NewBook += AddNewBook;
            adminForm.FormClosing += ShowFirstPage;
        }

        private void ShowAdminForm(object sender, EventArgs e)
        {
            adminForm.Show();
        }

        private void AddNewBook(object sender, NewBookEventArgs e)
        {
            Book = e.PendingBook;

            if (!LibraryData.Instance.Authors.Contains(Book.Author))
            {
                LibraryData.Instance.AddAuthor(Book.Author);
            }
            LibraryData.Instance.AddBook(Book);

            var barcode = barcodeGenerator.GenerateBarcode(Book.ID);
            BarcodeGenerated?.Invoke(this, new BarcodeGeneratedEventArgs { Barcode = barcode });

        }

        private void ShowFirstPage(object sender, EventArgs e)
        {
            firstPage.Show();
        }

        public class BarcodeGeneratedEventArgs : EventArgs
        {
            public Image Barcode { get; set; }
        }

        public delegate void BarcodeGeneratedEventHandler(object sender, BarcodeGeneratedEventArgs e);

    }
}
