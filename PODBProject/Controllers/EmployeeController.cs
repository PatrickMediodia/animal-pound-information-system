using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PODBProject.Models;
using static PODBProject.Models.EmployeeViewModel;

namespace PODBProject.Controllers
{
    public class EmployeeController : Controller
    {
        [Authorize(Roles = "Employee")]
        // GET: Employee
        public ActionResult Index()
        {
            var db = new PODBProjectEntities();
            return View(db.Announcements.ToList());
        }
        [Authorize(Roles = "Employee")]
        [HttpGet]
        public ActionResult CreateAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAnnouncement(AnnouncementModel announce)
        {
            string UserID = User.Identity.GetUserId();
            PODBProjectEntities entities = new PODBProjectEntities();
            Announcement announcement = new Announcement()
            {
                announceTitle = announce.announceTitle,
                announceText = announce.announceText,
                announceDate = DateTime.Now,
                Id = UserID,
                imageID = 1
            };
            entities.Announcements.Add(announcement);
            entities.SaveChanges();
            return View();
        }
        [Authorize(Roles = "Employee")]
        [HttpGet]
        public ActionResult EditAnnouncement()
        {

            return View();
        }
        [HttpPost]
        public ActionResult EditAnnouncement(AnnouncementModel announce)
        {
            return View();
        }
    }
}
