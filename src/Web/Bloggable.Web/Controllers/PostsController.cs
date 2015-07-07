namespace Bloggable.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using AutoMapper.QueryableExtensions;

    using Bloggable.Common.Extensions;
    using Bloggable.Services.Data.Contracts;
    using Bloggable.Web.Infrastructure.Extensions;
    using Bloggable.Web.Models.Posts.ViewModels;

    public class PostsController : BaseController
    {
        private readonly IPostsDataService postsData;

        public PostsController(IPostsDataService postsData)
        {
            this.postsData = postsData;
        }

        public ActionResult Details(int year, int month, string urlTitle, int id)
        {
            var post = this.postsData.All(p => p.Id == id).Project().To<PostDetailsViewModel>().FirstOrDefault();

            if (post == null || post.UrlTitle != urlTitle)
            {
                return this.RedirectToAction<HomeController>(c => c.Index(null)).WithErrorAlert("There is no such post...");
            }

            return this.View(post);
        }

        public ActionResult ByTag(int id, string urlName)
        {
            throw new NotImplementedException();
        }
    }
}