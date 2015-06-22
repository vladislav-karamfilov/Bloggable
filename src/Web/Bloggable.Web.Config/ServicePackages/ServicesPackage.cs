namespace Bloggable.Web.Config.ServicePackages
{
    using Bloggable.Services.Common.Cache;
    using Bloggable.Services.Common.Cache.Contracts;
    using Bloggable.Services.Data;
    using Bloggable.Services.Data.Contracts;

    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Packaging;

    public class ServicesPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            // TODO: Register with LINQ!
            var webRequestLifestyle = new WebRequestLifestyle();
            container.Register<ICacheService, HttpRuntimeCacheService>(webRequestLifestyle);
            container.Register<ICacheItemsProviderService, CacheItemsProviderService>(webRequestLifestyle);
            container.Register<ITagsDataService, TagsDataService>(webRequestLifestyle);
        }
    }
}
