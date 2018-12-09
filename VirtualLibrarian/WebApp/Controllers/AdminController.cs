using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        SelectList AuthorsList = new SelectList(LibraryDataIO.Instance.Context.Authors.AsEnumerable().Select(author =>
                        new SelectListItem
                        {
                            Value = author.ID.ToString(),
                            Text = $"{author.Name} {author.Surname}"
                        }).ToList(), "Value", "Text");

        SelectList PublishersList = new SelectList(LibraryDataIO.Instance.Context.Publishers.AsEnumerable().Select(publisher =>
                        new SelectListItem
                        {
                            Value = publisher.ID.ToString(),
                            Text = publisher.Name
                        }).ToList(), "Value", "Text");

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Publishers()
        {
            var dtPublisher = new DataTable();
            dtPublisher.Columns.Add("ID");
            dtPublisher.Columns.Add("Publisher");
            dtPublisher.Columns.Add("Book count");
            dtPublisher.Columns.Add("Books");

            foreach (var publisher in LibraryDataIO.Instance.Context.Books
                .GroupBy(book => book.Publisher).AsEnumerable()
                .Select(group => new
                {
                    ID = group.Key.ID,
                    Publisher = group.Key.Name,
                    Count = group.Select(x => x.ISBN).Distinct().Count(),
                    Books = group.Select(x => x.Title).Distinct().Take(5).Aggregate((x, y) => x + ", " + y) + "..."
                }).OrderByDescending(x => x.Count).ToList())
            {
                var row = dtPublisher.NewRow();
                row[0] = publisher.ID;
                row[1] = publisher.Publisher;
                row[2] = publisher.Count;
                row[3] = publisher.Books;
                dtPublisher.Rows.Add(row);
            }

            return View(dtPublisher);
        }

        //TODO: create view!!!
        public ActionResult Authors()
        {
            using(var cn = new SqlConnection(LibraryDataIO.Instance.ConnectionString))
            {
                var cmd = new SqlCommand("SELECT ID, Name, Surname, Country FROM Authors", cn);
                var da = new SqlDataAdapter();
                var dt = new DataTable();

                cn.Open();
                da.SelectCommand = cmd;
                da.Fill(dt);
                cn.Close();
                da.Dispose();
                return View(dt);
            }
        }

        public ActionResult Users()
        {
            string[] columns = { "ID", "Name", "Surname", "Email", "PhoneNr", "Books Taken" };
            var dtUsers = DataTransformationUtility.ToDataTable(LibraryDataIO.Instance.Context.Users.ToList());
            dtUsers.Columns.Add("Books Taken");
            foreach (DataRow row in dtUsers.Rows)
            {
                row["Books Taken"] = DataTransformationUtility.GetBookTitles(((HashSet<Book>)row["TakenBooks"]).ToList());
            }

            dtUsers = DataTransformationUtility.RemoveUnusedColumns(dtUsers, columns);
            //TODO: temp
            dtUsers.Columns["PhoneNr"].ColumnName = "Phone number";

            return View(dtUsers);
        }

        public ActionResult Books()
        {
            string[] columns = { "ID","ISBN", "Author", "Title", "Status" };
            DataTable dtLibraryBook = DataTransformationUtility.ToDataTable(LibraryDataIO.Instance.Context.Books.ToList());

            //prepare column with authors' full names
            dtLibraryBook.Columns.Add("Author");
            foreach (DataRow row in dtLibraryBook.Rows)
            {
                row["Author"] = DataTransformationUtility.GetAuthorNames(((HashSet<Author>)row["Authors"]).ToList());
            }

            dtLibraryBook = DataTransformationUtility.RemoveUnusedColumns(dtLibraryBook, columns);

            return View(dtLibraryBook);
        }

        public ActionResult AddBook()
        {
            return View();
        }

        // 
        // GET: /Admin/RemoveAuthor
        public async Task<ActionResult> RemoveAuthor(string AuthorId)
        {
            // logic
            return RedirectToAction("Authors");
        }

        // 
        // GET: /Admin/RemovePublisher 
        public async Task<ActionResult> RemovePublisher(string PublisherId)
        {
            // logic
            return RedirectToAction("Publishers");
        }

        // 
        // GET: /Admin/RemoveBook 
        public async Task<ActionResult> RemoveBook(string BookId)
        {
            var book = LibraryDataIO.Instance.FindBook(int.Parse(BookId));
            if (LibraryManager.ValidateBookDelete(book))
            {
                LibraryDataIO.Instance.RemoveBook(book);
            }
            return RedirectToAction("Books");
        }

        // 
        // GET: /Admin/RemoveUser 
        public async Task<ActionResult> RemoveUser(string UserId)
        {
            var user = LibraryDataIO.Instance.FindUser(int.Parse(UserId));
            if (LibraryManager.ValidateUserDelete(user))
            {
                LibraryDataIO.Instance.RemoveUser(user);
            }
            return RedirectToAction("Users");
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
                List<Author> authors = new List<Author>();

                int.TryParse(model.Qty, out int qty);
                int.TryParse(model.Pages, out int pages);

                string[] barcodePaths = new string[qty];

                var publisherID = int.Parse(model.Publisher);
                var publisher = LibraryDataIO.Instance.Context.Publishers.Where(p => p.ID == publisherID).Single();

                //TODO: get author list returned from frontend
                foreach(var author in model.Authors)
                {
                    authors.Add(LibraryDataIO.Instance.FindAuthor(int.Parse(author)));
                }

                foreach (var genre in model.Genre)
                {
                    genres = genres | (BookGenre)Enum.Parse(typeof(BookGenre), genre.ToString());
                }

                for (int i = 0; i < qty; i++)
                {
                    var newBook = new Book(title: model.Title, isbn: model.ISBN, authors: authors,
                                        publisher: publisher, genre: genres, description: model.Description, pages: pages);
                    LibraryDataIO.Instance.AddBook(newBook);

                    var barcodePath = barcodeGenerator.GenerateBarcode(newBook.ID);
                    barcodePaths[i] = barcodePath;
                }
                TempData["Success"] = model.Title + " added successfully!";
                TempData["BookCount"] = 5;

                string[] ImagesList = {
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d0/QR_code_for_mobile_English_Wikipedia.svg/220px-QR_code_for_mobile_English_Wikipedia.svg.png",
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d0/QR_code_for_mobile_English_Wikipedia.svg/220px-QR_code_for_mobile_English_Wikipedia.svg.png"
                };

                TempData["GeneratedImages"] = ImagesList;
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
                if (!LibraryDataIO.Instance.Context.Authors.Any(author => author.Name == newAuthor.Name && author.Surname == newAuthor.Surname))
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
                if(!LibraryDataIO.Instance.Context.Publishers.Any(publisher => publisher.Name == model.Name))
                {
                    LibraryDataIO.Instance.AddPublisher(model.Name, model.Country,model.Description);
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
