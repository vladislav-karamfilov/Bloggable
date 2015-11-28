namespace Bloggable.Web.Config.ServicePackages
{
    using System.Collections.Generic;
    using System.Web;

    using Bloggable.Data.Models;
    using Bloggable.Web.Config.Identity;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin;

    using SimpleInjector;
    using SimpleInjector.Advanced;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Packaging;

    public class IdentityPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            var webRequestLifestyle = new WebRequestLifestyle();

            container.Register<IUserStore<User>>(
                () => new UserStore<User>(container.GetInstance<IdentityDbContext<User>>()), 
                webRequestLifestyle);
            container.Register(
                () => container.IsVerifying()
                    ? new OwinContext(new Dictionary<string, object>()).Authentication
                    : HttpContext.Current.GetOwinContext().Authentication, 
                webRequestLifestyle);
            container.Register<ApplicationUserManager>(webRequestLifestyle);
            container.Register<ApplicationSignInManager>(webRequestLifestyle);
        }
    }
}
