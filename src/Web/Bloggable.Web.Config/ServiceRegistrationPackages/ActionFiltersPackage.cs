namespace Bloggable.Web.Config.ServiceRegistrationPackages
{
    using Bloggable.Web.Infrastructure.Filters.Contracts;

    using SimpleInjector;
    using SimpleInjector.Extensions;
    using SimpleInjector.Packaging;

    public class ActionFiltersPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.RegisterManyForOpenGeneric(typeof(IActionFilter<>), container.RegisterAll, typeof(IActionFilter<>).Assembly);
        }
    }
}
