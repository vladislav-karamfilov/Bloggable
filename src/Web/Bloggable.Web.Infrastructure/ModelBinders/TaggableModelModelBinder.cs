namespace Bloggable.Web.Infrastructure.ModelBinders
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Bloggable.Data.Models;
    using Bloggable.Services.Data.Contracts;
    using Bloggable.Web.Infrastructure.Models;

    public class TaggableModelModelBinder : DefaultModelBinder
    {
        private static readonly char[] TagSeparators = { ' ', ',', ';' };

        private readonly ITagsDataService tagsData;

        public TaggableModelModelBinder(ITagsDataService tagsData)
        {
            if (tagsData == null)
            {
                throw new ArgumentNullException(nameof(tagsData));
            }

            this.tagsData = tagsData;
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var taggableModel = base.BindModel(controllerContext, bindingContext) as ITaggableModel;
            if (taggableModel != null && !string.IsNullOrWhiteSpace(taggableModel.MergedTags))
            {
                if (taggableModel.Tags == null)
                {
                    taggableModel.Tags = new List<Tag>();
                }

                var splittedTags = taggableModel.MergedTags.Split(TagSeparators, StringSplitOptions.RemoveEmptyEntries);
                foreach (var tagName in splittedTags)
                {
                    var tag = this.tagsData.GetByNameOrCreate(tagName);
                    taggableModel.Tags.Add(tag);
                }
            }

            return taggableModel;
        }
    }
}
