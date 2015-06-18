namespace Bloggable.Web.Config.ServicePackages
{
    using Bloggable.Services.Administration.Base;
    using Bloggable.Services.Administration.Contracts;

    using SimpleInjector;
    using SimpleInjector.Extensions;
    using SimpleInjector.Packaging;

    public class AdministrationServicesPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.RegisterOpenGeneric(typeof(IDeletableEntityAdministrationService<>), typeof(DeletableEntityAdministrationService<>));
            container.RegisterOpenGeneric(typeof(IAdministrationService<>), typeof(AdministrationService<>));
        }
    }
}
