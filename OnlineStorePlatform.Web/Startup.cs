using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineStorePlatform.Web.Startup))]
namespace OnlineStorePlatform.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
