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
                url: "Posts/{year}/{month}/{urlTitle}/{id}",
                defaults: new { controller = "Posts", action = "Details" },
                namespaces: new[] { "Bloggable.Web.Controllers" });

            routes.MapRoute(
                name: "Blog posts by tag",
                url: "Posts/ByTag/{id}/{urlName}",
                defaults: new { controller = "Posts", action = "ByTag" },
                namespaces: new[] { "Bloggable.Web.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
