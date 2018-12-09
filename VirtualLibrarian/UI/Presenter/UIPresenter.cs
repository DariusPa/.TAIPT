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
        public User ActiveUser { get; set; }
        public event EventHandler UIClosed;


        public UIPresenter()
        {
            TakeBook.Instance.barcodeCamera.BarcodeDetected += OnBookDetected;
            ReturnBook.Instance.barcodeCamera.BarcodeDetected += OnBookReturn;
            Settings.Instance.SaveChanges += OnUserInfoChange;
            Settings.Instance.SoundSettingsChanged += OnSoundSettingsChanged;
        }

        public void PrepareUI(User activeUser)
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
            var book = LibraryDataIO.Instance.FindBook(int.Parse(e.DecodedText));
            TakeBook.Instance.HideScanner();
            if (LibraryManager.ValidateIssuing(ActiveUser, book))
            {
                ui.Speaker.SpeakAndWrite(StringConstants.aiWorking);
                LibraryManager.IssueBookToReader(ActiveUser, book);
                ui.Speaker.SpeakAndWrite(StringConstants.aiIssued);
            }
            else
            {
                ui.Speaker.SpeakAndWrite(StringConstants.aiIssuingFailed);
            }
        }

        private void OnBookReturn(object sender, BarcodeDetectedEventArgs e)
        {
            var book = LibraryDataIO.Instance.FindBook(int.Parse(e.DecodedText));
            ReturnBook.Instance.HideScanner();
            if (LibraryManager.ValidateReturning(ActiveUser, book))
            {
                ui.Speaker.SpeakAndWrite(StringConstants.aiWorking);
                LibraryManager.ReturnBook(ActiveUser, book);
                ui.Speaker.SpeakAndWrite(StringConstants.aiReturnedBook);
            }
            else
            {
                ui.Speaker.SpeakAndWrite(StringConstants.aiReturnFailed);
            }
            
        }

        private void OnSearchRequested(object sender, EventArgs e)
        {
            string[] columns = { "Title", "Author", "ISBN", "Genre", "Status"};
            DataTable dtLibraryBook = DataTransformationUtility.ToDataTable(LibraryDataIO.Instance.Context.Books.ToList());

            //prepare column with authors' full names
            dtLibraryBook.Columns.Add("Author");
            foreach(DataRow row in dtLibraryBook.Rows)
            {
                row["Author"] = DataTransformationUtility.GetAuthorNames(((HashSet<Author>)row["Authors"]).ToList());
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
            var takenBooks = LibraryDataIO.Instance.Context.Books
                    .Where(b => b.User.ID == ActiveUser.ID)
                    .AsEnumerable()
                     .Select(x => new
                     {
                         x.Title,
                         Author = DataTransformationUtility.GetAuthorNames(x.Authors.ToList()),
                         Issued = $"{x.IssueDate:yyyy/MM/dd}",
                         Returned = StringConstants.currentlyTakenString
                     });

            var historyBooks = LibraryDataIO.Instance.Context.ReadingHistory
                .Where(x => x.User.ID == ActiveUser.ID)
                .AsEnumerable()
                .Join(LibraryDataIO.Instance.Context.Books,
                       his => his.Book.ID,
                       book => book.ID,
                       (his, book) => new
                       {
                           book.Title,
                           Author = DataTransformationUtility.GetAuthorNames(book.Authors.ToList()),
                           Issued = $"{his.IssueDate:yyyy/MM/dd}",
                           Returned = $"{his.ReturnDate:yyyy/MM/dd}"
                       });

            var history = takenBooks.Concat(historyBooks);
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
                ui.Speaker.SpeakAndWrite(StringConstants.aiChangesSaved);
                ui.UpdateUser();
            }
            else
            {
                ui.Speaker.SpeakAndWrite(StringConstants.aiSaveChangesFailed);
            }
        }

        private void OnSoundSettingsChanged(object sender, SoundSettingsEventArgs args)
        {
            ui.Speaker.SoundEnabled = args.SoundEnabled;
        }


    }
}
