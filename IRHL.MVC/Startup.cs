using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IRHL.MVC.Startup))]
namespace IRHL.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
