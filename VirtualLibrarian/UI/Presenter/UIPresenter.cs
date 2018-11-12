using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            Settings.Instance.SaveChanges += OnUserInfoChange;
            Settings.Instance.SoundSettingsChanged += OnSoundSettingsChanged;
        }

        public void PrepareUI(IUserModel activeUser)
        {
            ActiveUser = activeUser;
            ui = new UI(ActiveUser);
            ui.FormClosed += OnUiClose;
            ui.SearchRequested += OnSearchRequested;
            ui.HistoryRequested += OnHistoryRequested;
            ui.Show();
        }

        private void OnBookDetected(object sender, BarcodeDetectedEventArgs e)
        {
            var book = LibraryDataIO.Instance.FindBook(e.DecodedText);
            if (ActiveUser != null && book != null && LibraryManager.IssueBookToReader(ActiveUser, book))
            {
                ui.Speaker.TellUser(StringConstants.aiIssued);
            }
            else
            {
                ui.Speaker.TellUser(StringConstants.aiIssuingFailed);
            }
            TakeBook.Instance.HideScanner();
        }

        private void OnBookReturn(object sender, BarcodeDetectedEventArgs e)
        {
            var book = LibraryDataIO.Instance.FindBook(e.DecodedText);
            if (LibraryManager.ReturnBook(ActiveUser, book))
            {
                ui.Speaker.TellUser(StringConstants.aiReturnedBook);
            }
            else
            {
                ui.Speaker.TellUser(StringConstants.aiReturnFailed);
            }
            ReturnBook.Instance.HideScanner();
            
        }

        private void OnSearchRequested(object sender, EventArgs e)
        {
            string[] columns = { "Title", "Author", "ISBN", "Genre", "Status"};
            DataTable dtLibraryBook = DataTransformationUtility.ToDataTable(LibraryDataIO.Instance.Books);

            //prepare column with authors' full names
            dtLibraryBook.Columns.Add("Author");
            foreach(DataRow row in dtLibraryBook.Rows)
            {
                row["Author"] = DataTransformationUtility.GetAuthorNames((List<int>)row["AuthorID"]);
            }
            DataTransformationUtility.EnableFiltering(dtLibraryBook, columns);
            Search.Instance.libraryGrid.DataSource = dtLibraryBook;
            Search.Instance.searchText.TextChanged += (s, a) => 
                dtLibraryBook.DefaultView.RowFilter = $"[_RowString] LIKE '%{Search.Instance.searchText.Text}%'";

            //hide unnecessary columns and rearange them
            foreach(DataGridViewColumn col in Search.Instance.libraryGrid.Columns)
            {
                if (((IList<string>)columns).Contains(col.Name))
                {
                    col.Visible = true;
                    col.DisplayIndex = Array.IndexOf(columns, col.Name);
                }
                else
                {
                    col.Visible = false;
                }
            }

        }

        private void OnHistoryRequested(object sender, EventArgs e)
        {
            var takenBooks = ActiveUser.TakenBooks
            .Join(LibraryDataIO.Instance.Books,
                  takenBook => takenBook,
                  libraryBook => libraryBook.ID,
                  (takenBook, libraryBook) => new {
                      libraryBook.Title,
                      Author = DataTransformationUtility.GetAuthorNames(libraryBook.AuthorID),
                      Issued = $"{libraryBook.IssueDate:yyyy/MM/dd}",
                      Returned = StringConstants.currentlyTakenString
                  });

            var bookHistory = ActiveUser.History
                .Join(LibraryDataIO.Instance.Books,
                      readBook => readBook.BookID,
                      libraryBook => libraryBook.ID,
                      (readBook, libraryBook) => new {
                          libraryBook.Title,
                          Author = DataTransformationUtility.GetAuthorNames(libraryBook.AuthorID),
                          Issued = $"{readBook.IssueDate:yyyy/MM/dd}",
                          Returned = $"{readBook.ReturnDate:yyyy/MM/dd}"
                      });

            var history = takenBooks.Concat(bookHistory);
            History.Instance.historyGrid.DataSource = history.ToList();
        }

        private void OnUiClose(object sender, EventArgs e)
        {
            ActiveUser = null;
            UIClosed?.Invoke(this, e);
        }

        private void OnUserInfoChange(object sender, UserRelatedEventArgs args)
        {
            if (LibraryDataIO.Instance.ChangeUserInfo(ActiveUser, args.UserName, args.UserSurname, args.UserEmail))
            {
                ui.Speaker.TellUser(StringConstants.aiChangesSaved);
                ui.UpdateUser();
            }
            else
            {
                ui.Speaker.TellUser(StringConstants.aiSaveChangesFailed);
            }
        }

        private void OnSoundSettingsChanged(object sender, SoundSettingsEventArgs args)
        {
            ui.Speaker.SoundEnabled = args.SoundEnabled;
        }


    }
}
