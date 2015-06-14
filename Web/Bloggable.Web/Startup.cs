using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bloggable.Web.Startup))]
namespace Bloggable.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
