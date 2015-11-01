namespace Bloggable.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    
    using Bloggable.Common.Extensions;
    using Bloggable.Services.Common.Mapping.Contracts;
    using Bloggable.Services.Data.Contracts;
    using Bloggable.Web.Infrastructure.Extensions;
    using Bloggable.Web.Models.Home;
    using Bloggable.Web.Models.Posts.ViewModels;

    public class BlogController : BaseController
    {
        private readonly IPostsDataService postsData;
        private readonly ITagsDataService tagsData;
        private readonly IMappingService mappingService;

        public BlogController(IPostsDataService postsData, ITagsDataService tagsData, IMappingService mappingService)
        {
            this.postsData = postsData;
            this.tagsData = tagsData;
            this.mappingService = mappingService;
        }

        public ActionResult Post(int year, int month, string urlTitle, int id)
        {
            var post = this.mappingService.MapCollection<PostDetailsViewModel>(this.postsData.All(p => p.Id == id)).FirstOrDefault();

            if (post == null ||
                !post.UrlTitle.Equals(urlTitle, StringComparison.OrdinalIgnoreCase) ||
                post.CreatedOn.Year != year ||
                post.CreatedOn.Month != month)
            {
                return this.RedirectToAction<HomeController>(c => c.Index(null)).WithErrorAlert("There is no such post...");
            }

            return this.View(post);
        }

        public ActionResult PostsByTag(int id, string urlName)
        {
            var tag = this.tagsData.GetById(id);

            if (tag == null || !tag.Name.ToUrl().Equals(urlName, StringComparison.OrdinalIgnoreCase))
            {
                return this.RedirectToAction<HomeController>(c => c.Index(null)).WithErrorAlert("There is no such tag...");
            }

            var postsByTag = this.mappingService.MapCollection<PostAnnotationViewModel>(this.postsData.ByTag(tag.Name));

            var model = new PostsByTagViewModel { TagId = id, TagName = tag.Name, TagUrlName = urlName, Posts = postsByTag };

            return this.View(model);
        }
    }
}