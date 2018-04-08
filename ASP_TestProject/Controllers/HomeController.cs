using ASP_TestProject.Sourse.Utilits;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_TestProject.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult UploadFile()
        {
            return View(32);
        }

        [HttpPost]
        public ActionResult UploadFile(int idIndividualPlan, HttpPostedFileBase file_Uploader)
        {
            WorkWithFile.UploadFile(System.IO.Path.GetFileName(file_Uploader.FileName), file_Uploader.InputStream);
            return RedirectToAction("Index", "Home");
        }

        public FileResult DownloadFile(int id)
        {
            string word = "application/docx";

            var file = Db.Files.FirstOrDefault(f => f.Id == id);
            var fileStream = new MemoryStream(file.File1);
            return File(file.File1, word, $"file id equal {file.Id}.docx");
        }

        public ActionResult Index()
        {
            var fileList = Db.Files.ToList();

            return View(fileList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}