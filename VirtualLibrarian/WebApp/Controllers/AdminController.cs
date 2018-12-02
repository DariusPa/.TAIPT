using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
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
            return View();
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
                TempData["Success"] = model.Name + " added successfully!";
                //data: model.Name and etc.
                return RedirectToAction("AddAuthor");
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
                TempData["Success"] = model.Name + " added successfully!";
                //data: model.Name and etc.
                return RedirectToAction("AddPublisher");
            }
            return View("AddPublisher");
        }
    }
}
