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
            container.RegisterCollection<IModelBinder>(new[] { typeof(TaggableModelModelBinder) });
        }
    }
}
