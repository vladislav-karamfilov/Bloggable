using Bloggable.Web;

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Bloggable.Web
{
    using System.Reflection;
    using System.Web.Mvc;

    using Bloggable.Data.Models;
    using Bloggable.Web.Config;
    using Bloggable.Web.Config.Identity;
    using Bloggable.Web.Infrastructure.Filters;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = SimpleInjectorConfig.RegisterServices(Assembly.GetExecutingAssembly());

            FilterConfig.RegisterGlobalFilters(
                GlobalFilters.Filters,
                new object[] { new ActionFilterDispatcher(container.GetAllInstances), });

            AuthConfig.ConfigureAuth(app, container.GetInstance<IdentityDbContext<User>>);

            ModelBinderConfig.RegisterModelBinders(container);
        }
    }
}
