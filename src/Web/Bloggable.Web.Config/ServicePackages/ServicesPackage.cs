namespace Bloggable.Web.Config.ServicePackages
{
    using System.Linq;
    using System.Reflection;

    using Bloggable.Common.Constants;
    using Bloggable.Services.Common;
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
            var serviceAssemblies = new[]
            {
                typeof(IService).Assembly, 
                Assembly.Load(AssemblyConstants.ServicesData), 
                Assembly.Load(AssemblyConstants.ServicesAdministration),
            };

            var registrations = serviceAssemblies
                .SelectMany(a => a.GetExportedTypes())
                .Where(t => typeof(IService).IsAssignableFrom(t) && !t.IsAbstract && !t.IsGenericTypeDefinition)
                .Select(t => new { Service = t.GetInterfaces().Single(i => i != typeof(IService)), Implementation = t })
                .ToList();

            var webRequestLifestyle = new WebRequestLifestyle();
            foreach (var registration in registrations)
            {
                container.AddRegistration(
                    registration.Service,
                    webRequestLifestyle.CreateRegistration(registration.Service, registration.Implementation, container));
            }

            //// TODO: Register with LINQ!

            ////container.Register<ICacheService, HttpRuntimeCacheService>(webRequestLifestyle);
            ////container.Register<ICacheItemsProviderService, CacheItemsProviderService>(webRequestLifestyle);
            ////container.Register<ITagsDataService, TagsDataService>(webRequestLifestyle);
            ////container.Register<IPostsDataService, PostsDataService>(webRequestLifestyle);
            ////container.Register<ICommentsDataService, CommentsDataService>(webRequestLifestyle);
        }
    }
}
