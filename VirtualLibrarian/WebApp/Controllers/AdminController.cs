using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AdminController : Controller
    {
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
            return View();
        }

        public ActionResult AddAuthor()
        {
            return View();
        }

        public ActionResult AddPublisher()
        {
            return View();
        }
    }
}
