namespace Bloggable.Web.Controllers
{
    using System.Web.Mvc;

    using Bloggable.Common.Constants;
    using Bloggable.Services.Common.Mapping.Contracts;
    using Bloggable.Services.Data.Contracts;
    using Bloggable.Web.Models.Common.ViewModels;

    public class TagsController : BaseController
    {
        private const int MostPopularTagsToTake = 20;

        private readonly ITagsDataService tagsData;
        private readonly IMappingService mappingService;

        public TagsController(ITagsDataService tagsData, IMappingService mappingService)
        {
            this.tagsData = tagsData;
            this.mappingService = mappingService;
        }

        [ChildActionOnly]
        [OutputCache(Duration = CacheConstants.DefaultCacheSeconds)]
        public ActionResult MostPopularTagsPartial()
        {
            var mostPopularTagsData = this.tagsData.GetMostPopularTags(MostPopularTagsToTake);
            var mostPopularTags = this.mappingService.MapCollection<TagViewModel>(mostPopularTagsData);

            return this.PartialView("_MostPopularTags", mostPopularTags);
        }
    }
}