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
using VirtualLibrarian.Data;
using VirtualLibrarian.Helpers;
using VirtualLibrarian.Model;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DashboardController : Controller
    {
        public IUserModel ActiveUser { get; set; }

        public DashboardController()
        {
            //TODO: get actual user (with label returned from recognition)"
            ActiveUser = LibraryDataIO.Instance.FindUser("1");
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
            foreach (DataRow row in dtLibraryBook.Rows)
            {
                row["Author"] = DataTransformationUtility.GetAuthorNames((List<int>)row["AuthorID"]);
            }

            dtLibraryBook = DataTransformationUtility.RemoveUnusedColumns(dtLibraryBook, columns);

            return View(dtLibraryBook);
        }

        public ActionResult Take()
        {
            return View();
        }

        public ActionResult Return()
        {
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
            return View(dtHistory);
        }

        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Account");
        }
    }
}
