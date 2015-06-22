namespace Bloggable.Web.Infrastructure.ModelBinders
{
    using System;
    using System.Web.Mvc;

    using Bloggable.Data.Contracts;

    public class EntityModelBinderProvider : IModelBinderProvider
    {
        private readonly IServiceProvider serviceProvider;

        public EntityModelBinderProvider(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IModelBinder GetBinder(Type modelType)
        {
            IModelBinder modelBinder = null;

            if (typeof(IEntity).IsAssignableFrom(modelType))
            {
                var modelBinderType = typeof(EntityModelBinder<>).MakeGenericType(modelType);
                modelBinder = this.serviceProvider.GetService(modelBinderType) as IModelBinder;
            }

            return modelBinder;
        }
    }
}
