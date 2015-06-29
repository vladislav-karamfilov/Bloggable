namespace Bloggable.Web.Config.ServicePackages
{
    using System.Data.Entity;

    using Bloggable.Common.Constants;
    using Bloggable.Data;
    using Bloggable.Data.Contracts.Repositories;
    using Bloggable.Data.Models;
    using Bloggable.Data.Repositories;

    using Microsoft.AspNet.Identity.EntityFramework;

    using SimpleInjector;
    using SimpleInjector.Extensions;
    using SimpleInjector.Packaging;

    public class DataPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.RegisterPerWebRequest(() => new BloggableDbContext(AppSettingConstants.DefaultDbConnectionName));
            container.RegisterPerWebRequest<DbContext>(container.GetInstance<BloggableDbContext>);
            container.RegisterPerWebRequest<IdentityDbContext<User>>(container.GetInstance<BloggableDbContext>);

            container.RegisterOpenGeneric(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            container.RegisterOpenGeneric(typeof(IRepository<>), typeof(EfRepository<>));
        }
    }
}
