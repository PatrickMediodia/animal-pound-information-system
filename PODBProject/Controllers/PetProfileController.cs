using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PODBProject.Actions;
using PODBProject.Models;
namespace PODBProject.Controllers
{
    public class PetProfileController : Controller
    {
        String userId;
        // GET: PetProfile
        public ActionResult Index()
        {
            userId = User.Identity.GetUserId();
            PODBProjectEntities entities = new PODBProjectEntities();

                if ((entities.PetProfiles.Where(e => e.Id.Equals(userId)).FirstOrDefault() == null))
                {
                    return View("PetProfileNotFound");
                }
                else
                {
                    return View(entities.PetProfiles.Where(e => e.Id.Equals(userId)).ToList());
                }
            
        }
        // GET: PetProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PetProfile/Create
        [HttpPost]
        public ActionResult Create(PetProfileModel petProfile, HttpPostedFileBase file)
        {
                PODBProjectEntities entities = new PODBProjectEntities();
                PostPhoto photo = new PostPhoto();
                String path = photo.PostPhotoPet(file);

            int ImageID = entities.Images.Where(e => e.imagePath.Equals(path)).FirstOrDefault().imageID;

            if (petProfile.mChipId == null)
            {
                petProfile.mChipId = "Not Microchipped";
            }
            var pet = new PetProfile
            {
                    Id = User.Identity.GetUserId(),
                    imageID = ImageID,
                    petName = petProfile.petName,
                    petType = petProfile.petType,
                    petBreed = petProfile.petBreed,
                    gender = petProfile.gender,
                    mChipId = petProfile.mChipId,
                    mChipStatus = petProfile.mChipStatus,
                    nueterStatus = petProfile.nueterStatus
                };
                entities.PetProfiles.Add(pet);
            try
            {
                entities.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
            return RedirectToAction("Index");
        }

        // GET: PetProfile/Edit/5
        public ActionResult Edit(int id)
        {
            using (PODBProjectEntities entities = new PODBProjectEntities())
            {
                return View(entities.PetProfiles.Where(e=>e.petId.Equals(id)).FirstOrDefault());
            }
        }

        // POST: PetProfile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PetProfile petProfile , HttpPostedFileBase file)
        {
            int imageid;
            PODBProjectEntities entities = new PODBProjectEntities();
            String userId = User.Identity.GetUserId();

            PostPhoto photo = new PostPhoto();
            String path = photo.PostPhotoPet(file);

            if (file != null)
            {
                imageid = entities.Images.Where(e => e.imagePath.Equals(path)).FirstOrDefault().imageID;
            }
            else
            {
                imageid = entities.Announcements.Where(e => e.announceId.Equals(id)).FirstOrDefault().imageID;
            }
            try
            {
                using (PODBProjectEntities edit = new PODBProjectEntities())
                {
                    petProfile.Id = User.Identity.GetUserId();
                    petProfile.imageID = 1;
                    edit.Entry(petProfile).State = EntityState.Modified;
                    edit.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: PetProfile/Delete/5
        public ActionResult Delete(int id)
        {
            using (PODBProjectEntities entities = new PODBProjectEntities())
            {
                return View(entities.PetProfiles.Where(e => e.petId.Equals(id)).FirstOrDefault());
            }
        }

        // POST: PetProfile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (PODBProjectEntities entities = new PODBProjectEntities())
                {
                    PetProfile petProfile = entities.PetProfiles.Where(e => e.petId.Equals(id)).FirstOrDefault();
                    entities.PetProfiles.Remove(petProfile);
                    entities.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
