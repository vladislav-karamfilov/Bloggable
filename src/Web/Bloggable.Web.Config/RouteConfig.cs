namespace Bloggable.Web.Config
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Blog post",
                url: "Blog/{year}/{month}/{urlTitle}/{id}",
                defaults: new { controller = "Blog", action = "PostDetails" },
                namespaces: new[] { "Bloggable.Web.Controllers" });

            routes.MapRoute(
                name: "Blog posts by tag",
                url: "Blog/PostsByTag/{id}/{urlName}",
                defaults: new { controller = "Blog", action = "PostsByTag" },
                namespaces: new[] { "Bloggable.Web.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Bloggable.Web.Controllers" });
        }
    }
}
