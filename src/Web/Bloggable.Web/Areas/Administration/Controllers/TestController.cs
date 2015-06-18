namespace Bloggable.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Bloggable.Data.Models;
    using Bloggable.Services.Administration.Base;
    using Bloggable.Web.Controllers;

    public class TestController : AdministrationController
    {
        private readonly AuditInfoAdministrationService<Post> postsAdministrationService;

        public TestController(AuditInfoAdministrationService<Post> postsAdministrationService)
        {
            this.postsAdministrationService = postsAdministrationService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            this.postsAdministrationService.Delete(2);
            return this.Content("deleted");
        }
    }
}