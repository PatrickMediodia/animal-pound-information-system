using System;
using System.Collections.Generic;
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