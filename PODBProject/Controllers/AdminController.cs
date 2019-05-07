using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PODBProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PODBProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateUser()
        {
               return View();
        }
        [HttpPost]
        public ActionResult CreateUser(FormCollection form)
        {
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string UserName = form["txtEmail"];
            string email = form["txtEmail"];
            string password = form["txtPassword"];

            var user = new ApplicationUser();
            user.UserName = UserName;
            user.Email = email;
            var newuser = usermanager.Create(user,password);
            return View();
        }
        public ActionResult AssignRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AssignRole(FormCollection form)
        {
            string username = form["txtUser"];
            string roles = form["Roles"];

            var context = new ApplicationDbContext();
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            usermanager.AddToRole(user.Id, roles);
            return View("Index");
        }
    }
}