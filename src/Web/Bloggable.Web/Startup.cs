using Bloggable.Web;

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Bloggable.Web
{
    using System.Reflection;
    using System.Web.Mvc;

    using Bloggable.Web.Config;
    using Bloggable.Web.Config.Identity;
    using Bloggable.Web.Infrastructure.Filters;

    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = SimpleInjectorConfig.RegisterServices(Assembly.GetExecutingAssembly());

            AuthConfig.ConfigureAuth(app, container);

            GlobalFilters.Filters.Add(new ActionFilterDispatcher(container.GetAllInstances));
        }
    }
}
