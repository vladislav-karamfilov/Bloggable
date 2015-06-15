namespace Bloggable.Web.Controllers
{
    using System;
    using System.Linq;
    using System.ServiceModel.Syndication;
    using System.Web.Mvc;

    using Bloggable.Data;
    using Bloggable.Web.Infrastructure.ActionResults;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}