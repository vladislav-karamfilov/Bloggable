namespace Bloggable.Web.Config
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;

    using Bloggable.Common.Constants;
    using Bloggable.Data;
    using Bloggable.Data.Contracts;
    using Bloggable.Data.Models;
    using Bloggable.Data.Repositories.Base;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin;

    using SimpleInjector;
    using SimpleInjector.Advanced;
    using SimpleInjector.Extensions;
    using SimpleInjector.Integration.Web.Mvc;

    public static class SimpleInjectorConfig
    {
        public static Container RegisterServices(Assembly mvcControllersAssembly)
        {
            var container = new Container();

            InitializeContainer(container);

            container.RegisterMvcControllers(mvcControllersAssembly);

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            return container;
        }

        private static void InitializeContainer(Container container)
        {
            container.RegisterPerWebRequest(() => new BloggableDbContext(AppSettingConstants.DefaultDbConnectionName));
            container.RegisterPerWebRequest<IdentityDbContext<User>>(container.GetInstance<BloggableDbContext>);
            container.RegisterPerWebRequest<DbContext>(container.GetInstance<BloggableDbContext>);
            container.RegisterPerWebRequest<IUserStore<User>>(() => new UserStore<User>(container.GetInstance<IdentityDbContext<User>>()));
            container.RegisterPerWebRequest(() => container.IsVerifying()
                ? new OwinContext(new Dictionary<string, object>()).Authentication
                : HttpContext.Current.GetOwinContext().Authentication);
            container.RegisterOpenGeneric(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            container.RegisterOpenGeneric(typeof(IRepository<>), typeof(EfRepository<>));
        }
    }
}