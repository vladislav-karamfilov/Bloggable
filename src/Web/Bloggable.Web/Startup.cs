[assembly: Microsoft.Owin.OwinStartupAttribute(typeof(Bloggable.Web.Startup))]

namespace Bloggable.Web
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Bloggable.Data;
    using Bloggable.Data.Migrations;
    using Bloggable.Web.Config;
    using Bloggable.Web.Config.Identity;

    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = SimpleInjectorConfig.RegisterServices(Assembly.GetExecutingAssembly());
            AuthConfig.ConfigureAuth(app, container);
        }
    }
}
