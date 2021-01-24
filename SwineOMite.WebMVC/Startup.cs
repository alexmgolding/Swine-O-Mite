using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SwineOMite.WebMVC.Startup))]
namespace SwineOMite.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
