using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoBro.Web.Startup))]
namespace GoBro.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
