using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using VirtualLibrarian.BusinessLogic;
using VirtualLibrarian.Data;
using VirtualLibrarian.Helpers;
using VirtualLibrarian.Model;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DashboardController : Controller
    {
        public IUserModel ActiveUser { get; set; }
        private SpeakingAI speaker;


        public DashboardController()
        {
            //TODO: get actual user (with label returned from recognition)"
            ActiveUser = LibraryDataIO.Instance.FindUser("1");
            //TODO: check why it stops the page from loading
            //speaker = new SpeakingAI();

        }

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Search()
        {
            string[] columns = { "Title", "Author", "Publisher", "ISBN", "Genre", "Status" };
            DataTable dtLibraryBook = DataTransformationUtility.ToDataTable(LibraryDataIO.Instance.Books);

            //prepare column with authors' full names
            dtLibraryBook.Columns.Add("Author");
            dtLibraryBook.Columns.Add("Publisher");
            foreach (DataRow row in dtLibraryBook.Rows)
            {
                row["Author"] = DataTransformationUtility.GetAuthorNames((List<int>)row["AuthorID"]);
                row["Publisher"] = LibraryDataIO.Instance.Publishers.Find(publisher => publisher.ID == (int)row["PublisherID"]).Name;
            }

            dtLibraryBook = DataTransformationUtility.RemoveUnusedColumns(dtLibraryBook, columns);

            //speaker.Speak(StringConstants.aiSearchLibraryGreeting);
            return View(dtLibraryBook);
        }

        public ActionResult Take()
        {
            //speaker.Speak(StringConstants.aiScanBookQRString);
            return View();
        }

        public ActionResult Return()
        {
            //speaker.Speak(StringConstants.aiReturnBookString);
            return View();
        }

        public ActionResult History()
        {
            //TODO: remove this when user validation logic is implemented for the whole dashboard
            if (ActiveUser == null) return View(new DataTable());

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

            var dtHistory = DataTransformationUtility.ToDataTable(takenBooks.Concat(bookHistory).ToList());
            //speaker.Speak(StringConstants.aiReadingHistoryGreeting);
            return View(dtHistory);
        }

        public ActionResult Settings()
        {
            //speaker.Speak(StringConstants.aiAccountSettingsGreeting);
            return View();
        }

        public ActionResult Logout()
        {
            //speaker.Speak(StringConstants.aiGoodbye);
            return RedirectToAction("Index", "Account");
        }
    }
}
