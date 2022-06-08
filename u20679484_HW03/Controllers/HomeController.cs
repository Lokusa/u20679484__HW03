using u20679484_HW03.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace u20679484_HW03.Controllers
{
    public class HomeController : Controller
    {

        // show the home page
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        // Recives the file and radio button input
        [HttpPost]
        public ActionResult Index(string FileType, HttpPostedFileBase file)
        {


            // we are not if the file ha been uploaded
            if (file != null)
            {
                string extension = Path.GetExtension(file.FileName);
                // ensure that the file is image for the selcted button
                
                if (FileType == "Image")
                {
                    // Save Image in the folder under media folder which is image
                    file.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Images"), Path.GetFileName(file.FileName)));
                    ViewBag.Message = "File uploaded successfully";
                }
                else if (FileType == "Video")
                {
                    
                    file.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Videos"), Path.GetFileName(file.FileName)));
                    ViewBag.Message = "File uploaded successfully";
                }
                else if (FileType == "Document")
                {
                   
                    file.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Documents"), Path.GetFileName(file.FileName)));
                    ViewBag.Message = "File uploaded successfully";
                }
            }
            else
            {
                ViewBag.Message = "Plese Select a file";

            }
            
            //return RedirectToAction("actionname", "controller name");
            return View();
        }

        public ActionResult About()
        {
            return View();
        }



    }
}