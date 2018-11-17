using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
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
            return View();
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
