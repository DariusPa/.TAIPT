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
        public JsonResult LoginBitmap(string value)
        {
            var originalBitmap = DataTransformationUtility.StringToBitmap(value);
            var grayImage = DataTransformationUtility.BitmapToGrayImage(originalBitmap);

            if (!LibraryDataIO.Instance.IsRecogniserTrained)
            {
                return Json(new { success = false, err = 1});
            }
            var label = LibraryDataIO.Instance.FaceRecognition.Recognize(grayImage);

            return label==null ? Json(new { success = false}) : Json(new { success = true, user = label });
        }

        // 
        // POST: /Account/RegisterBitmap
        [HttpPost]
        [AllowAnonymous]
        public JsonResult RegisterBitmap(List<string> values, string name, string surname, string email)
        {
            var originalBitmaps = DataTransformationUtility.StringToBitmapList(values);
            var grayImages = DataTransformationUtility.BitmapToGrayImageList(originalBitmaps);

            if (LibraryDataIO.Instance.IsRecogniserTrained &&  LibraryDataIO.Instance.FaceRecognition.Recognize(grayImages)!=null)
            {
                /*user exists*/
                return Json(new { success = false });
            }
            else
            {
                var newUser = new User(name, surname, email);
                LibraryDataIO.Instance.AddUser(newUser);
                LibraryDataIO.Instance.FaceRecognition.StoreNewFace(grayImages, newUser.ID.ToString());
                return Json(new { success = true });
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
