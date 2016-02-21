namespace Bloggable.Web.Config.ServicePackages
{
    using System.Data.Entity;

    using Bloggable.Common.Constants;
    using Bloggable.Data;
    using Bloggable.Data.Contracts.Helpers;
    using Bloggable.Data.Contracts.Repositories;
    using Bloggable.Data.Helpers;
    using Bloggable.Data.Models;
    using Bloggable.Data.Repositories;

    using Microsoft.AspNet.Identity.EntityFramework;

    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Packaging;

    public class DataPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            var webRequestLifestyle = new WebRequestLifestyle();

            container.Register(() => new BloggableDbContext(AppSettingConstants.DefaultDbConnectionName), webRequestLifestyle);
            container.Register<DbContext>(container.GetInstance<BloggableDbContext>, webRequestLifestyle);
            container.Register<IdentityDbContext<User>>(container.GetInstance<BloggableDbContext>, webRequestLifestyle);

            container.Register(typeof(IRepository<>), typeof(EfRepository<>), webRequestLifestyle);
            container.Register(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>), webRequestLifestyle);

            container.Register<IEntityKeyTypesProvider, EfEntityKeyTypesProvider>();
        }
    }
}
