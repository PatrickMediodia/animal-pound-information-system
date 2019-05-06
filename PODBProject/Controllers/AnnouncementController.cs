using Microsoft.AspNet.Identity;
using PODBProject.Actions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PODBProject.Controllers
{
    public class AnnouncementController : Controller
    {
        [Authorize(Roles = "Employee")]
        // GET: Announcement
        public ActionResult Index()
        {
            PODBProjectEntities entities = new PODBProjectEntities();
                return View(entities.Announcements.ToList());
        }
        [Authorize(Roles = "Employee")]
        // GET: Announcement/Details/5
        public ActionResult Details(int id)
        {
            using (PODBProjectEntities entities = new PODBProjectEntities())
            {
                return View(entities.Announcements.Where(e => e.announceId.Equals(id)).FirstOrDefault());
            }
        }
        [Authorize(Roles = "Employee")]
        // GET: Announcement/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Announcement/Create
        [HttpPost]
        public ActionResult Create(Announcement announce, HttpPostedFileBase file)
        {
            PODBProjectEntities entities = new PODBProjectEntities();

            PostPhoto photo = new PostPhoto();
            String path = photo.PostPhotoAnnouncement(file);

            int ImageID = entities.Images.Where(e => e.imagePath.Equals(path)).FirstOrDefault().imageID;

            try
            {
                using (PODBProjectEntities announcement = new PODBProjectEntities())
                {
                    announce.Id = User.Identity.GetUserId();
                    announce.announceDate = DateTime.Now;
                    announce.imageID = ImageID;
                    entities.Announcements.Add(announce);
                    entities.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Employee")]
        // GET: Announcement/Edit/5
        public ActionResult Edit(int id)
        {
            using (PODBProjectEntities entities = new PODBProjectEntities())
            {
                return View(entities.Announcements.Where(e => e.announceId.Equals(id)).FirstOrDefault());
            }
        }

        // POST: Announcement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Announcement announce, HttpPostedFileBase file)
        {
            int imageid;
            PODBProjectEntities entities = new PODBProjectEntities();
            String userId = User.Identity.GetUserId();

            PostPhoto photo = new PostPhoto();
            String path = photo.PostPhotoAnnouncement(file);
            if (file != null)
            {
                imageid = entities.Images.Where(e => e.imagePath.Equals(path)).FirstOrDefault().imageID;
            }
            else
            {
                imageid = entities.PetProfiles.Where(e => e.petId.Equals(id)).FirstOrDefault().imageID;
            }
            try
          {
               using (PODBProjectEntities announcement = new PODBProjectEntities())
               {
                    announce.Id = User.Identity.GetUserId();
                    announce.announceDate = DateTime.Now;
                    announce.imageID = imageid;
                    announcement.Entry(announce).State = EntityState.Modified;
                    announcement.SaveChanges();
               }
           return RedirectToAction("Index");
          } 
          catch
                {
                    return View();
                }
        }

        [Authorize(Roles = "Employee")]
        // GET: Announcement/Delete/5
        public ActionResult Delete(int id)
        {
            using (PODBProjectEntities entities = new PODBProjectEntities())
            {
                return View(entities.Announcements.Where(e => e.announceId.Equals(id)).FirstOrDefault());
            }
        }

        // POST: Announcement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,Announcement announce)
        {
            PODBProjectEntities entities = new PODBProjectEntities();
            try
            {
                Announcement announcement = entities.Announcements.Find(id);
                entities.Announcements.Remove(announcement);
                entities.SaveChanges();

               return RedirectToAction("Index");   
            }
            catch(NullReferenceException)
            {
                return View();
            }
        }
    }
}
