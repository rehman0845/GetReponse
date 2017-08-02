using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestGet360.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        [HttpPost]
        public ActionResult GetFile(HttpPostedFileBase fiel)
        {
            
            TempData["Httppostedfile"] = fiel.FileName;
            TempData["path_filename"] = System.IO.Path.GetFileName(fiel.FileName);
            return RedirectToAction("Index");
        }
    }
}
