namespace Bloggable.Web.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    
    public class ErrorsController : BaseController
    {
        public ActionResult Index()
        {
            this.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return this.View("Error");
        }

        public ActionResult BadRequest()
        {
            this.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return this.View();
        }

        public ActionResult PageNotFound()
        {
            this.Response.StatusCode = (int)HttpStatusCode.NotFound;
            return this.View();
        }
    }
}