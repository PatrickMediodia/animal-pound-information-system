using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Data.Entity;
using PODBProject.Models;


namespace PODBProject.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {         
            var db = new PODBProjectEntities();
            return View(db.Announcements);
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