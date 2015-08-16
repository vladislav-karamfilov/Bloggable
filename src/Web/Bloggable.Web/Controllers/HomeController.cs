namespace Bloggable.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Bloggable.Common.Constants;
    using Bloggable.Services.Data.Contracts;
    using Bloggable.Web.Models.Home;

    using PagedList;

    public class HomeController : BaseController
    {
        private readonly IPostsDataService postsData;

        public HomeController(IPostsDataService postsData)
        {
            this.postsData = postsData;
        }

        public ActionResult Index(int? page)
        {
            var currentPage = page > 0 ? page.Value : 1;

            var posts = this.postsData
                .All()
                .OrderByDescending(p => p.CreatedOn)
                .Project()
                .To<PostAnnotationViewModel>()
                .ToPagedList(currentPage, GlobalConstants.DefaultPageSize);

            return this.View(posts);
        }
    }
}