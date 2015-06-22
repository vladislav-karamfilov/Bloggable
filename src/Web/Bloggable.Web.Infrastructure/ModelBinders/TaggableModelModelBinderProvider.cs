namespace Bloggable.Web.Infrastructure.ModelBinders
{
    using System;
    using System.Web.Mvc;

    using Bloggable.Web.Infrastructure.Models;

    public class TaggableModelModelBinderProvider : IModelBinderProvider
    {
        private readonly IServiceProvider serviceProvider;

        public TaggableModelModelBinderProvider(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IModelBinder GetBinder(Type modelType)
        {
            IModelBinder modelBinder = null;
            if (typeof(ITaggableModel).IsAssignableFrom(modelType))
            {
                modelBinder = this.serviceProvider.GetService(typeof(TaggableModelModelBinder)) as IModelBinder;
            }

            return modelBinder;
        }
    }
}
