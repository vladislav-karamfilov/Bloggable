namespace Bloggable.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using Bloggable.Services.Data.Contracts;

    public class PostsController : BaseController
    {
        private readonly IPostsDataService postsData;

        public PostsController(IPostsDataService postsData)
        {
            this.postsData = postsData;
        }

        public ActionResult Details(int year, int month, string urlTitle, int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult ByTag(int id, string urlName)
        {
            throw new NotImplementedException();
        }
    }
}