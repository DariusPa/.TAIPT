using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VirtualLibrarian.BusinessLogic;
using VirtualLibrarian.Data;
using VirtualLibrarian.Helpers;
using VirtualLibrarian.Model;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AdminController : Controller
    {
        private BarcodeGenerator barcodeGenerator;

        public AdminController()
        {
            barcodeGenerator = new BarcodeGenerator(LibraryDataIO.Instance.DataDirPath + @"Barcodes");
            ViewBag.myAuthors = AuthorsList;
            ViewBag.myPublishers = PublishersList;
            ViewBag.genres = Enum.GetValues(typeof(BookGenre));

        }

        SelectList AuthorsList = new SelectList(LibraryDataIO.Instance.Authors.Select(author =>
                        new SelectListItem
                        {
                            Value = author.ID.ToString(),
                            Text = author.FullName
                        }).ToList(), "Value", "Text");

        SelectList PublishersList = new SelectList(LibraryDataIO.Instance.Publishers.Select(publisher =>
                        new SelectListItem
                        {
                            Value = publisher.ID.ToString(),
                            Text = publisher.Name
                        }).ToList(), "Value", "Text");

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            string[] columns = {"ID", "Name", "Surname", "Email", "PhoneNr","Books Taken" };
            var dtUsers = DataTransformationUtility.ToDataTable(LibraryDataIO.Instance.Users);
            dtUsers.Columns.Add("Books Taken");
            foreach(DataRow row in dtUsers.Rows)
            {
                row["Books Taken"] = DataTransformationUtility.GetBookTitles((List<int>)row["TakenBooks"]);
            }

            dtUsers = DataTransformationUtility.RemoveUnusedColumns(dtUsers, columns);
            //TODO: temp
            dtUsers.Columns["PhoneNr"].ColumnName = "Phone number";

            return View(dtUsers);
        }

        public ActionResult Books()
        {
            string[] columns = { "ID","ISBN", "Author", "Title", "Status" };
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
                BookGenre genres = new BookGenre();
                List<int> authors = new List<int>();

                int.TryParse(model.Qty, out int qty);
                int.TryParse(model.Pages, out int pages);
                var publisher = int.Parse(model.Publisher);

                foreach (var genre in model.Genre)
                {
                    genres = genres | (BookGenre)Enum.Parse(typeof(BookGenre), genre.ToString());
                }

                /*TODO: fix front, so that author list would be returned*/
                //foreach (Author author in model.Author)
                //{
                //    authors.Add(author.ID);
                //}
                authors.Add(int.Parse(model.Author));

                for (int i = 0; i < qty; i++)
                {
                    var newBook = new Book(title: model.Title, isbn: model.ISBN, authorID: authors,
                                        publisherID: publisher, genre: genres, description: model.Description, pages: pages);
                    LibraryDataIO.Instance.AddBook(newBook);

                    //TODO: pass barcodes to frontend so they would be displayed
                    var barcode = barcodeGenerator.GenerateBarcode(newBook.ID);
                }
                TempData["Success"] = model.Title + " added successfully!";
                return RedirectToAction("AddBook");
            }
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
