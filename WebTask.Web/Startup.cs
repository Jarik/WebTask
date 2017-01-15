using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebTask.Web.Startup))]
namespace WebTask.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
