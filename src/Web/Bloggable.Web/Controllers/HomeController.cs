namespace Bloggable.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Bloggable.Services.Data.Contracts;
    using Bloggable.Web.Models.Home;

    using PagedList;

    public class HomeController : BaseController
    {
        private const int PageSize = 10;

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
                .ToPagedList(currentPage, PageSize);

            return this.View(posts);
        }
    }
}