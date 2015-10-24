namespace Bloggable.Web.Config.ServicePackages
{
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;

    using Bloggable.Common.Constants;
    using Bloggable.Data.Contracts;
    using Bloggable.Web.Infrastructure.ModelBinders;

    using SimpleInjector;
    using SimpleInjector.Packaging;

    public class ModelBindersPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            var entityModelBinders = Assembly.Load(AssemblyConstants.DataModels)
                .GetExportedTypes()
                .Where(t => typeof(IEntity).IsAssignableFrom(t) && !t.IsAbstract)
                .Select(t => typeof(EntityModelBinder<>).MakeGenericType(t));

            var modelBinders = entityModelBinders.Concat(new[] { typeof(TaggableModelModelBinder) });

            container.RegisterCollection<IModelBinder>(modelBinders);
        }
    }
}
