namespace Bloggable.Web.Config.ServiceRegistrationPackages
{
    using System.Collections.Generic;
    using System.Web;

    using Bloggable.Data;
    using Bloggable.Data.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin;

    using SimpleInjector;
    using SimpleInjector.Advanced;
    using SimpleInjector.Packaging;

    public class IdentityPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.RegisterPerWebRequest<IdentityDbContext<User>>(container.GetInstance<BloggableDbContext>);
            
            container.RegisterPerWebRequest<IUserStore<User>>(() => new UserStore<User>(container.GetInstance<IdentityDbContext<User>>()));
            container.RegisterPerWebRequest(() => container.IsVerifying()
                ? new OwinContext(new Dictionary<string, object>()).Authentication
                : HttpContext.Current.GetOwinContext().Authentication);
        }
    }
}
