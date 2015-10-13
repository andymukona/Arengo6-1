using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Arengo6_MVC.Startup))]
namespace Arengo6_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
