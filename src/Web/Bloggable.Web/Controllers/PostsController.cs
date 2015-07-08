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
    using Bloggable.Web.Models.Home;
    using Bloggable.Web.Models.Posts.ViewModels;

    public class PostsController : BaseController
    {
        private readonly IPostsDataService postsData;
        private readonly ITagsDataService tagsData;

        public PostsController(IPostsDataService postsData, ITagsDataService tagsData)
        {
            this.postsData = postsData;
            this.tagsData = tagsData;
        }

        public ActionResult Details(int year, int month, string urlTitle, int id)
        {
            var post = this.postsData.All(p => p.Id == id).Project().To<PostDetailsViewModel>().FirstOrDefault();

            if (post == null || !post.UrlTitle.Equals(urlTitle, StringComparison.OrdinalIgnoreCase))
            {
                return this.RedirectToAction<HomeController>(c => c.Index(null)).WithErrorAlert("There is no such post...");
            }

            return this.View(post);
        }

        public ActionResult ByTag(int id, string urlName)
        {
            var tag = this.tagsData.GetById(id);

            if (tag == null || !tag.Name.ToUrl().Equals(urlName, StringComparison.OrdinalIgnoreCase))
            {
                return this.RedirectToAction<HomeController>(c => c.Index(null)).WithErrorAlert("There is no such tag...");
            }

            var postsByTag = this.postsData.ByTag(tag.Name).Project().To<PostAnnotationViewModel>();

            var model = new PostsByTagViewModel { TagId = id, TagName = tag.Name, TagUrlName = urlName, Posts = postsByTag };

            return this.View(model);
        }
    }
}