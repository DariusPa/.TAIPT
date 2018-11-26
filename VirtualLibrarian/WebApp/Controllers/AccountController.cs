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

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private IFaceRecognition faceRecognition;

        public AccountController()
        {
            faceRecognition = new FaceRecognition();
            faceRecognition.LoadRecognizer();
            faceRecognition.TrainRecognizer();
        }
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
            
            Bitmap bmp;
            Mat mat;
            Image<Gray, Byte> img;
            string base64 = imageSource.Substring(imageSource.IndexOf(',') + 1);
            byte[] data = Convert.FromBase64String(base64);

            using (MemoryStream ms = new MemoryStream(data))
            {
                bmp = (Bitmap)Image.FromStream(ms);
            }
            img = new Image<Gray, byte>(bmp);
            mat = img.Mat;

            CvInvoke.EqualizeHist(mat, mat);

            mat.Save($"{LibraryDataIO.Instance.FacesPath}\\test.bmp");

            Rectangle[] facesDetected = faceRecognition.DetectFaces(mat);

            foreach (Rectangle face in facesDetected)
            {
                var grayFace = new Mat(mat, face);
                img = grayFace.ToImage<Gray, byte>();
                mat.Dispose();
                CvInvoke.Resize(img, img, new Size(100, 100), 0, 0, Inter.Cubic);

                    var label = faceRecognition.Recognize(img);
                    
            }

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
        public JsonResult RegisterBitmap(List<String> values)
        {
            byte[][] faces = new byte[10][];

            int i = 0;
            foreach (string element in values)
            {
                var base64Data = Regex.Match(element, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
                var binData = Convert.FromBase64String(base64Data);

                using (var stream = new MemoryStream(binData))
                {
                    faces[i] = stream.ToArray();
                }
                i++;
            }

            //faces = array of 10 images binary data

            return Json(new { response = 1 });
        }

        // 
        // GET: /Account/Register 
        [AllowAnonymous]
        public ActionResult Register(string Name, string Surname, string Email)
        {
            ViewBag.Name = Name;
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
