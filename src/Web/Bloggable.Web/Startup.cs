[assembly: Microsoft.Owin.OwinStartupAttribute(typeof(Bloggable.Web.Startup))]

namespace Bloggable.Web
{
    using Bloggable.Web.Config.Identity;

    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AuthConfig.ConfigureAuth(app);
        }
    }
}
