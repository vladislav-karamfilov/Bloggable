namespace Bloggable.Web.Controllers
{
    using System.Web.Mvc;

    public class ErrorsController : BaseController
    {
        public ActionResult General() => this.View("Error");

        public ActionResult PageNotFound() => this.View();
    }
}