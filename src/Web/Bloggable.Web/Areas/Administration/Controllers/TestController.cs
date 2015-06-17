namespace Bloggable.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    public class TestController : Controller
    {
        public ActionResult Index()
        {
            return this.Content("Hello from the administration area!");
        }
    }
}