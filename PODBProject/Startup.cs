using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using PODBProject.Models;

[assembly: OwinStartupAttribute(typeof(PODBProject.Startup))]
namespace PODBProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUsersAndRoles();
        }
        private void CreateUsersAndRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!rolemanager.RoleExists("Admin"))
            {
                //Create Default Role
                var role = new IdentityRole("Admin");
                rolemanager.Create(role);

                //Create Default Users
                var user = new ApplicationUser();
                user.UserName = "CVOsuperadmin@domain.com";
                user.Email = "CVOsuperadmin@domain.com";
                string pwd = "Pass@CVOsuperadmin12345678";
                var newuser = usermanager.Create(user, pwd);
                if (newuser.Succeeded)
                {
                    usermanager.AddToRole(user.Id, "Admin");
                }
            }
        }
    }
}
