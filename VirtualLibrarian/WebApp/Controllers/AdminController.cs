using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VirtualLibrarian.Data;
using VirtualLibrarian.Helpers;
using VirtualLibrarian.Model;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AdminController : Controller
    {

        SelectList AuthorsList = new SelectList(new List<SelectListItem>
        {
            new SelectListItem { Text = "Author1", Value = "1"},
            new SelectListItem { Text = "Author2", Value = "2"},
        }, "Value", "Text");
        SelectList PublishersList = new SelectList(new List<SelectListItem>
        {
            new SelectListItem { Text = "Publisher1", Value = "1"},
            new SelectListItem { Text = "Publisher2", Value = "2"},
        }, "Value", "Text");

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult Books()
        {
            string[] columns = { "ISBN", "Author", "Title", "Status" };
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

        public ActionResult AddBook()
        {
            ViewBag.myAuthors = AuthorsList;
            ViewBag.myPublishers = PublishersList;

            return View();
        }

        // 
        // POST: /Admin/SubmitBook 
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SubmitBook(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["Success"] = model.Title + " added successfully!";
                //data: model.Name and etc.
                return RedirectToAction("AddBook");
            }

            ViewBag.myAuthors = AuthorsList;
            ViewBag.myPublishers = PublishersList;
            return View("AddBook");
        }

        public ActionResult AddAuthor()
        {
            return View();
        }

        // 
        // POST: /Admin/SubmitAuthor 
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SubmitAuthor(AuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newAuthor = new Author(model.Name, model.Surname, model.Country, model.Description);
                if (!LibraryDataIO.Instance.Authors.Any(author => author.FullName == newAuthor.FullName))
                {
                    LibraryDataIO.Instance.AddAuthor(newAuthor);
                    TempData["Success"] = model.Name + " added successfully!";
                    return RedirectToAction("AddAuthor");
                }
                else
                {
                    TempData["ErrorMessage"] = StringConstants.authorExists;
                }
            }
            return View("AddAuthor");
        }

        public ActionResult AddPublisher()
        {
            return View();
        }

        // 
        // POST: /Admin/SubmitPublisher 
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SubmitPublisher(PublisherViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newPublisher = new Publisher(model.Name, model.Country, model.Description);
                if(!LibraryDataIO.Instance.Publishers.Any(publisher => publisher.Name == newPublisher.Name))
                {
                    LibraryDataIO.Instance.AddPublisher(newPublisher);
                    TempData["Success"] = model.Name + " added successfully!";
                    return RedirectToAction("AddPublisher");
                }
                else
                {
                    TempData["ErrorMessage"] = StringConstants.publisherExists;
                }
                return RedirectToAction("AddPublisher");
            }
            return View("AddPublisher");
        }
    }
}
