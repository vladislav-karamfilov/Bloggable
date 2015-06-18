namespace Bloggable.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Bloggable.Web.Controllers;

    public class TestController : AdministrationController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return this.View("asd");
            return this.Content("Hello from the administration area!");
        }
    }
}