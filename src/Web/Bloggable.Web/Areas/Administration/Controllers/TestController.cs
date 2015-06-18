namespace Bloggable.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Bloggable.Web.Controllers;

    public class TestController : AdministrationController
    {
        public ActionResult Index()
        {
            return this.Content("Hello from the administration area!");
        }
    }
}