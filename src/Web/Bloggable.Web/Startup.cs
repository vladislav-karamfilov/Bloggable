[assembly: Microsoft.Owin.OwinStartupAttribute(typeof(Bloggable.Web.Startup))]

namespace Bloggable.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
