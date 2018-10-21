using System.Windows.Forms;
using VirtualLibrarian.Data;
using VirtualLibrarian.Helpers;
using VirtualLibrarian.Model;

namespace VirtualLibrarian.Presenter
{
    public class UIPresenter
    {
        private FirstPage firstPage;
        private UI ui;
        public IUserModel ActiveUser { get; set; }


        public UIPresenter(UI ui, IUserModel user)
        {
            this.ui = ui;
            ActiveUser = user;
            Search.Instance.barcodeCamera.BarcodeDetected += OnBookDetected;
            ReturnBook.Instance.BookReturn += OnBookReturn;
        }

        private void OnBookDetected(object sender, BarcodeDetectedEventArgs e)
        {
            var book = LibraryDataIO.Instance.FindBook(e.DecodedText);
            if (ActiveUser != null && book != null && LibraryDataIO.Instance.IssueBookToReader(ActiveUser, book))
            {
                MessageBox.Show("OK");
            }
            else MessageBox.Show("Issuing failed!");
            Search.Instance.HideScanner();
        }

        private void OnBookReturn(object sender, BookRelatedEventArgs e)
        {
            if (!LibraryDataIO.Instance.ReturnBook(ActiveUser, e.Book))
                MessageBox.Show("Error occured");
            ui.RefreshDataGrid();
        }


    }
}
