namespace Bloggable.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Bloggable.Data.Models;
    using Bloggable.Services.Administration.Base;
    using Bloggable.Web.Controllers;

    public class PostsController : AdministrationController
    {
        private readonly DeletableEntityAdministrationService<Post> postsAdministrationService;

        public PostsController(DeletableEntityAdministrationService<Post> postsAdministrationService)
        {
            this.postsAdministrationService = postsAdministrationService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }
    }
}