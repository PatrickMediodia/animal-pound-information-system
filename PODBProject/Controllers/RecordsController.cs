using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PODBProject.Controllers
{
    public class RecordsController : Controller
    {
        private PODBProjectEntities entities;


        public RecordsController()
        {
            entities = new PODBProjectEntities();
        }
        [HttpGet]
        public ActionResult AddOrEditViolations(int id = 0)
        {
            if (id == 0)
                return View(new Violation());
            else
            {
                using (PODBProjectEntities entities = new PODBProjectEntities())
                {
                    return View(entities.Violations.Where(x => x.violationId == id).FirstOrDefault<Violation>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEditViolations(Violation violation)
        {
            using (PODBProjectEntities entities = new PODBProjectEntities())
            {
                if (violation.violationId == 0)
                {
                    entities.Violations.Add(violation);
                    entities.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    entities.Entry(violation).State = EntityState.Modified;
                    entities.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }

        }

        [HttpPost]
        public ActionResult DeleteViolations(int id)
        {
            using (PODBProjectEntities entities = new PODBProjectEntities())
            {
                Violation emp = entities.Violations.Where(x => x.violationId == id).FirstOrDefault<Violation>();
                entities.Violations.Remove(emp);
                entities.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AddOrEditReports(int id = 0)
        {
            if (id == 0)
                return View(new Report());
            else
            {
                using (PODBProjectEntities entities = new PODBProjectEntities())
                {
                    return View(entities.Violations.Where(x => x.violationId == id).FirstOrDefault<Violation>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEditReports(Report report)
        {
            using (PODBProjectEntities entities = new PODBProjectEntities())
            {
                if (report.reportId == 0)
                {
                    entities.Reports.Add(report);
                    entities.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    entities.Entry(report).State = EntityState.Modified;
                    entities.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }

        }

        [HttpPost]
        public ActionResult DeleteReports(int id)
        {
            using (PODBProjectEntities entities = new PODBProjectEntities())
            {
                Report emp = entities.Reports.Where(x => x.reportId == id).FirstOrDefault<Report>();
                entities.Reports.Remove(emp);
                entities.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult AddOrEditAdoptions(int id = 0)
        {
            if (id == 0)
                return View(new Adoption());
            else
            {
                using (PODBProjectEntities entities = new PODBProjectEntities())
                {
                    return View(entities.Adoptions.Where(x => x.adoptionId == id).FirstOrDefault<Adoption>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEditAdoptions(Adoption adoption)
        {
            using (PODBProjectEntities entities = new PODBProjectEntities())
            {
                if (adoption.adoptionId == 0)
                {
                    entities.Adoptions.Add(adoption);
                    entities.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    entities.Entry(adoption).State = EntityState.Modified;
                    entities.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }

        }

        [HttpPost]
        public ActionResult DeleteViolationsAdoption(int id)
        {
            using (PODBProjectEntities entities = new PODBProjectEntities())
            {
                Adoption emp = entities.Adoptions.Where(x => x.adoptionId == id).FirstOrDefault<Adoption>();
                entities.Adoptions.Remove(emp);
                entities.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }

        //public ActionResult GetDataViolations()
        //{
        //    using(PODBProjectEntities entities = new PODBProjectEntities())
        //    {
        //        List<Violation> violations = entities.Violations.ToList<Violation>();
        //        return Json(new { data = violations }, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //public ActionResult GetDataReports()
        //{
        //    using (PODBProjectEntities entities = new PODBProjectEntities())
        //    {
        //        List<Report> reports = entities.Reports.ToList<Report>();
        //        return Json(new { data = reports }, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //public ActionResult GetDataAdoptions()
        //{
        //    using (PODBProjectEntities entities = new PODBProjectEntities())
        //    {
        //        List<Adoption> adoptions = entities.Adoptions.ToList<Adoption>();
        //        return Json(new { data = adoptions }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        public ActionResult Violations()
        {
            return View(entities.Violations.ToList());
        }


        public ActionResult Adoption()
        {
            return View(entities.Adoptions.ToList());
        }

        public ActionResult Services()
        {
            return View(entities.Services.ToList());
        }
    }
}