namespace Bloggable.Web.Config.ServicePackages
{
    using System.Linq;
    using System.Reflection;

    using Bloggable.Common.Constants;
    using Bloggable.Common.Extensions;
    using Bloggable.Services.Administration.Base;
    using Bloggable.Services.Administration.Contracts;
    using Bloggable.Services.Common;

    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Packaging;

    public class ServicesPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            var webRequestLifestyle = new WebRequestLifestyle();

            // Generic types
            container.Register(typeof(IDeletableEntityAdministrationService<>), typeof(DeletableEntityAdministrationService<>), webRequestLifestyle);
            container.Register(typeof(IAdministrationService<>), typeof(AdministrationService<>), webRequestLifestyle);

            // Non-generic types
            var serviceAssemblies = new[]
            {
                typeof(IService).Assembly,
                Assembly.Load(AssemblyConstants.ServicesData),
                Assembly.Load(AssemblyConstants.ServicesAdministration),
            };

            var nonGenericTypeServiceRegistrationsInfo = serviceAssemblies
                .SelectMany(a => a.GetExportedTypes())
                .Where(t => typeof(IService).IsAssignableFrom(t) && !t.IsAbstract && !t.IsGenericTypeDefinition)
                .Select(t => new
                {
                    ConcreteType = t,
                    ServiceTypes = t.GetInterfaces().Where(i => i.IsPublic && i != typeof(IService) && !i.GenericTypeArguments.Any())
                })
                .ToList();

            foreach (var registration in nonGenericTypeServiceRegistrationsInfo)
            {
                registration.ServiceTypes.ForEach(serviceType => container.Register(serviceType, registration.ConcreteType, webRequestLifestyle));
            }
        }
    }
}
