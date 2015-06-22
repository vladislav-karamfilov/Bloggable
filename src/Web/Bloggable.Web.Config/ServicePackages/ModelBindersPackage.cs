namespace Bloggable.Web.Config.ServicePackages
{
    using System.Web.Mvc;

    using Bloggable.Web.Infrastructure.ModelBinders;

    using SimpleInjector;
    using SimpleInjector.Packaging;

    public class ModelBindersPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.RegisterAll<IModelBinder>(typeof(TaggableModelModelBinder));
        }
    }
}
