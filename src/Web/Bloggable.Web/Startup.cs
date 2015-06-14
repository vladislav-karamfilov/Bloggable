using Bloggable.Web;

using Microsoft.Owin;

[assembly: OwinStartupAttribute(typeof(Startup))]
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
