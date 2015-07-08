namespace Bloggable.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Bloggable.Common.Constants;
    using Bloggable.Services.Data.Contracts;
    using Bloggable.Web.Models.Common.ViewModels;

    public class TagsController : BaseController
    {
        private const int MostPopularTagsToTake = 20;

        private readonly ITagsDataService tagsData;

        public TagsController(ITagsDataService tagsData)
        {
            this.tagsData = tagsData;
        }

        [OutputCache(Duration = CacheConstants.DefaultCacheSeconds)]
        public ActionResult MostPopularTagsPartial()
        {
            var mostPopularTags = this.tagsData.GetMostPopularTags(MostPopularTagsToTake).Project().To<TagViewModel>();

            return this.PartialView("_MostPopularTags", mostPopularTags);
        }
    }
}