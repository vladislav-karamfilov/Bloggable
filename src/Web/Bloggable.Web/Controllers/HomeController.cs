namespace Bloggable.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Bloggable.Data.Contracts;
    using Bloggable.Data.Models;

    public class HomeController : Controller
    {
        private readonly IDeletableEntityRepository<Post> posts;

        public HomeController(IDeletableEntityRepository<Post> posts)
        {
            this.posts = posts;
        }

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

        public ActionResult AllPosts()
        {
            return this.Json(this.posts.All().Select(x => new { x.Author.UserName, x.Title, x.SubTitle, x.Content }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}