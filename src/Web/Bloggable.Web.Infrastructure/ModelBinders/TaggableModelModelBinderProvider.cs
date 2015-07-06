namespace Bloggable.Web.Infrastructure.ModelBinders
{
    using System;
    using System.Web.Mvc;

    using Bloggable.Web.Infrastructure.Models;

    public class TaggableModelModelBinderProvider : IModelBinderProvider
    {
        private readonly Func<TaggableModelModelBinder> taggableModelModelBinderFactory;

        public TaggableModelModelBinderProvider(Func<TaggableModelModelBinder> taggableModelModelBinderFactory)
        {
            this.taggableModelModelBinderFactory = taggableModelModelBinderFactory;
        }

        public IModelBinder GetBinder(Type modelType)
        {
            IModelBinder modelBinder = null;

            if (typeof(ITaggableModel).IsAssignableFrom(modelType))
            {
                modelBinder = this.taggableModelModelBinderFactory();
            }

            return modelBinder;
        }
    }
}
