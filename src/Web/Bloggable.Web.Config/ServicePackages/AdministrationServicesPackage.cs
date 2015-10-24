namespace Bloggable.Web.Config.ServicePackages
{
    using Bloggable.Services.Administration;
    using Bloggable.Services.Administration.Base;
    using Bloggable.Services.Administration.Contracts;

    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Packaging;

    public class AdministrationServicesPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            var webRequestLifestyle = new WebRequestLifestyle();

            container.Register(typeof(IDeletableEntityAdministrationService<>), typeof(DeletableEntityAdministrationService<>), webRequestLifestyle);
            container.Register(typeof(IAdministrationService<>), typeof(AdministrationService<>), webRequestLifestyle);
            container.Register<ISettingsAdministrationService, SettingsAdministrationService>(webRequestLifestyle);
            container.Register<IPagesAdministrationService, PagesAdministrationService>(webRequestLifestyle);
        }
    }
}
