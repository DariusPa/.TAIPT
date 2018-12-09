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
        public User ActiveUser { get; set; }

        public DashboardController()
        {
            if (SharedResources.Instance.ID != 0)
            {
               ActiveUser = LibraryDataIO.Instance.FindUser(SharedResources.Instance.ID);
            }
            RedirectToAction("Index", "Account");

        }

        public ActionResult Index()
        {
            SharedResources.Instance.Speaker.Speak(StringConstants.AIGreeting(ActiveUser?.Name));
            return View();
        }

        public ActionResult Search()
        {
            string[] columns = { "Title", "Author", "Publisher", "ISBN", "Genre", "Status" };
            DataTable dtLibraryBook = DataTransformationUtility.ToDataTable(LibraryDataIO.Instance.Context.Books.ToList());

            //prepare column with authors' full names
            dtLibraryBook.Columns.Add("Author");
            //TODO: cleanup!
            dtLibraryBook.Columns.Remove("Publisher");
            dtLibraryBook.Columns.Add("Publisher");

            foreach (DataRow row in dtLibraryBook.Rows)
            {
                row["Author"] = DataTransformationUtility.GetAuthorNames(((HashSet<Author>)row["Authors"]).ToList());
                row["Publisher"] = LibraryDataIO.Instance.FindPublisher((int)row["PublisherID"]).Name;
            }

            dtLibraryBook = DataTransformationUtility.RemoveUnusedColumns(dtLibraryBook, columns);

            SharedResources.Instance.Speaker.Speak(StringConstants.aiSearchLibraryGreeting);
            return View(dtLibraryBook);
        }

        public ActionResult Take()
        {
            SharedResources.Instance.Speaker.Speak(StringConstants.aiScanBookQRString);
            return View();
        }

        public ActionResult Return()
        {
            SharedResources.Instance.Speaker.Speak(StringConstants.aiReturnBookString);
            return View();
        }

        public ActionResult History()
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

            var dtHistory = DataTransformationUtility.ToDataTable(takenBooks.Concat(historyBooks).ToList());
            SharedResources.Instance.Speaker.Speak(StringConstants.aiReadingHistoryGreeting);
            return View(dtHistory);
        }

        public ActionResult Settings()
        {
            SharedResources.Instance.Speaker.Speak(StringConstants.aiAccountSettingsGreeting);
            return View();
        }

        public ActionResult Logout()
        {
            SharedResources.Instance.ID = 0;
            SharedResources.Instance.Speaker.Speak(StringConstants.aiGoodbye);
            return RedirectToAction("Index", "Account");
        }
    }
}
