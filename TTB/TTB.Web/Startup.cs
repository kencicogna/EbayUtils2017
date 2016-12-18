using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TTB.Web.Startup))]
namespace TTB.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
