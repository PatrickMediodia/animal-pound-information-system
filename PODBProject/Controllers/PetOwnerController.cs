using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PODBProject.Models;
using System.Data.Entity;

namespace PODBProject.Controllers
{
    public class PetOwnerController : Controller
    {
        //
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (PODBProjectEntities db = new PODBProjectEntities())
            {
                List<PetOwnerProfile> poList = db.PetOwnerProfiles.ToList<PetOwnerProfile>();
                return Json(new { data = poList }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new PetOwnerProfile());
            else
            {
                using (PODBProjectEntities db = new PODBProjectEntities())
                {
                    return View(db.PetOwnerProfiles.Where(x => x.profileId==id).FirstOrDefault<PetOwnerProfile>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(PetOwnerProfile po)
        {
            using (PODBProjectEntities db = new PODBProjectEntities())
            {
                if (po.profileId == 0)
                {
                    db.PetOwnerProfiles.Add(po);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else {
                    db.Entry(po).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (PODBProjectEntities db = new PODBProjectEntities())
            {
                PetOwnerProfile emp = db.PetOwnerProfiles.Where(x => x.profileId == id).FirstOrDefault<PetOwnerProfile>();
                db.PetOwnerProfiles.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}