using System;
using System.Windows.Forms;
using VirtualLibrarian.Data;
using VirtualLibrarian.Helpers;
using VirtualLibrarian.Model;

namespace VirtualLibrarian.Presenter
{
    public class UIPresenter
    {
        private UI ui;
        public IUserModel ActiveUser { get; set; }
        public event EventHandler UIClosed;


        public UIPresenter()
        {
            TakeBook.Instance.barcodeCamera.BarcodeDetected += OnBookDetected;
            ReturnBook.Instance.barcodeCamera.BarcodeDetected += OnBookReturn;
        }

        public void PrepareUI(IUserModel activeUser)
        {
            ActiveUser = activeUser;
            ui = new UI(ActiveUser);
            ui.FormClosed += OnUiClose;
            ui.Show();
        }

        private void OnBookDetected(object sender, BarcodeDetectedEventArgs e)
        {
            var book = LibraryDataIO.Instance.FindBook(e.DecodedText);
            if (ActiveUser != null && book != null && LibraryManager.IssueBookToReader(ActiveUser, book))
            {
                ui.Speaker.TellUser("Book has been successfully issued to you.",ui.AI);
            }
            else ui.Speaker.TellUser("Issuing failed!", ui.AI);
            TakeBook.Instance.HideScanner();
        }

        private void OnBookReturn(object sender, BarcodeDetectedEventArgs e)
        {
            var book = LibraryDataIO.Instance.FindBook(e.DecodedText);
            if (LibraryManager.ReturnBook(ActiveUser, book))
                ui.Speaker.TellUser("You successfully returned the book.", ui.AI);
            else ui.Speaker.TellUser("Returning failed! You might have returned this book earlier or it had been taken by another user.",ui.AI);
            ReturnBook.Instance.HideScanner();
            
        }

        private void OnUiClose(object sender, EventArgs e)
        {
            ActiveUser = null;
            UIClosed?.Invoke(this, e);
        }


    }
}
