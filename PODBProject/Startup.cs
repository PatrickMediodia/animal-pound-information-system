using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PODBProject.Startup))]
namespace PODBProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
