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
using VirtualLibrarian.BusinessLogic;
using System.Drawing;
using System.IO;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Connect(ConnectToDashboardViewModel model)
        {
            return View();
        }

        // 
        // POST: /Account/Bitmap 
        [HttpPost]
        [AllowAnonymous]
        public JsonResult Bitmap(FormCollection imageData)
        {
            string imageSource = imageData["name"];

            string base64 = imageSource.Substring(imageSource.IndexOf(',') + 1);
            byte[] data = Convert.FromBase64String(base64);

            return Json(new { response = "Response" });
        }

        // 
        // GET: /Account/Register 
        [AllowAnonymous]
        public ActionResult Register(string Name, string Surname, string Email)
        {
            return View();
        }

        // 
        // POST: /Account/Register 
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Register", new { name = model.Name, surname = model.Surname, email = model.Email });
            }
            return View("Index");
        }
    }
}
