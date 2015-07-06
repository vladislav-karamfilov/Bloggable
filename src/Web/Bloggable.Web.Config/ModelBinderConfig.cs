namespace Bloggable.Web.Config
{
    using System;
    using System.Web.Mvc;

    using Bloggable.Common.Extensions;
    using Bloggable.Web.Infrastructure.ModelBinders;

    public class ModelBinderConfig
    {
        public static void RegisterModelBinders(IServiceProvider serviceProvider)
        {
            ModelBinderProviders.BinderProviders.Add(new TaggableModelModelBinderProvider(serviceProvider.GetService<TaggableModelModelBinder>));
            ModelBinderProviders.BinderProviders.Add(new EntityModelBinderProvider(serviceProvider));
        }
    }
}
