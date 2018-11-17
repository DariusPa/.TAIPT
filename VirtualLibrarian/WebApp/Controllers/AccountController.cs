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

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {

        private FaceCamera faceCam;

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Connect(ConnectToDashboardViewModel model)
        {
            faceCam = new FaceCamera(250, 350);
            faceCam.RecognizeExistingFace();
            return View();
            // Load Emgu
            // return View();
            // return RedirectToAction("Index", "Dashboard");
        }

        // 
        // GET: /Account/Register 
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        // 
        // POST: /Account/Register 
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            return View("Index");
        }
    }
}
