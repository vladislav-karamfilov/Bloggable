namespace Bloggable.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    
    using Bloggable.Common.Constants;
    using Bloggable.Services.Common.Mapping.Contracts;
    using Bloggable.Services.Data.Contracts;
    using Bloggable.Web.Models.Home;

    using PagedList;

    public class HomeController : BaseController
    {
        private readonly IPostsDataService postsData;
        private readonly IMappingService mappingService;

        public HomeController(IPostsDataService postsData, IMappingService mappingService)
        {
            if (postsData == null)
            {
                throw new ArgumentNullException(nameof(postsData));
            }

            if (mappingService == null)
            {
                throw new ArgumentNullException(nameof(mappingService));
            }

            this.postsData = postsData;
            this.mappingService = mappingService;
        }

        public ActionResult Index(int? page)
        {
            var currentPage = page > 0 ? page.Value : 1;

            var posts = this.postsData.All().OrderByDescending(p => p.CreatedOn);

            var postsPage = this.mappingService
                .MapCollection<PostAnnotationViewModel>(posts)
                .ToPagedList(currentPage, GlobalConstants.DefaultPageSize);

            return this.View(postsPage);
        }
    }
}