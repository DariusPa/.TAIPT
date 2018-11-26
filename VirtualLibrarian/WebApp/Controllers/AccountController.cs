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
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using VirtualLibrarian.Data;
using VirtualLibrarian.Helpers;
using VirtualLibrarian.Model;

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

            return Json(new { response = "Response" });
        }

        // 
        // POST: /Account/LoginBitmap 
        [HttpPost]
        [AllowAnonymous]
        public JsonResult LoginBitmap(FormCollection imageData)
        {
	    // is login gaunamas face bmp masyvas jsonu
            return Json(new { response = "valid" });
        }

        // 
        // POST: /Account/RegisterBitmap
        [HttpPost]
        [AllowAnonymous]
        public JsonResult RegisterBitmap(List<string> values, string name, string surname, string email)
        {
            var originalBitmaps = DataTransformationUtility.StringToBitmapList(values);
            var grayImages = DataTransformationUtility.BitmapToGrayImage(originalBitmaps);

            var faceRecognition = new FaceRecognition();
            faceRecognition.LoadRecognizer();
            var trained = faceRecognition.TrainRecognizer();

            if (trained && faceRecognition.Recognize(grayImages) != "")
            {
                /*user exists*/
                return Json(false);
            }
            else
            {
                var newUser = new User(name, surname, email);
                faceRecognition.StoreNewFace(grayImages, newUser.ID.ToString());
                LibraryDataIO.Instance.AddUser(newUser);
                return Json(true);
            }
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

        // 
        // GET: /Account/Register 
        [AllowAnonymous]
        public ActionResult Register(string Name, string Surname, string Email)
        {
            ViewBag.Name = Name;
            ViewBag.Surname = Surname;
            ViewBag.Email = Email;
            return View();
        }
    }
}
