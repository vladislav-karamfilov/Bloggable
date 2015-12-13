namespace Bloggable.Web.Infrastructure.ModelBinders
{
    using System;
    using System.Web.Mvc;

    using Bloggable.Web.Infrastructure.Models;

    public class TaggableModelModelBinderProvider : IModelBinderProvider
    {
        private readonly Func<TaggableModelModelBinder> taggableModelModelBinderFunc;

        public TaggableModelModelBinderProvider(Func<TaggableModelModelBinder> taggableModelModelBinderFunc)
        {
            if (taggableModelModelBinderFunc == null)
            {
                throw new ArgumentNullException(nameof(taggableModelModelBinderFunc));
            }

            this.taggableModelModelBinderFunc = taggableModelModelBinderFunc;
        }

        public IModelBinder GetBinder(Type modelType)
        {
            IModelBinder modelBinder = null;

            if (typeof(ITaggableModel).IsAssignableFrom(modelType))
            {
                modelBinder = this.taggableModelModelBinderFunc();
            }

            return modelBinder;
        }
    }
}
