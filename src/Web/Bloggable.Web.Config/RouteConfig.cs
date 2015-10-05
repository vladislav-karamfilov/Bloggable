namespace Bloggable.Web.Config
{
    using System.Reflection;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Bloggable.Common.Constants;
    using Bloggable.Web.Infrastructure.Extensions;
    using Bloggable.Web.Infrastructure.RouteConstraints;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.AppendTrailingSlash = false;
            routes.LowercaseUrls = true;
            
            routes
                .MapRoute(
                   name: "Page",
                   url: "{id}",
                   defaults: new { controller = "Pages", action = "Page" },
                   namespaces: new[] { "Bloggable.Web.Controllers" })
                .WithConstraints("id", new SkipControllersWithIndexActionRouteConstraint(Assembly.Load(AssemblyConstants.Web)));

            routes.MapRoute(
                name: "Blog post",
                url: "Blog/{year}/{month}/{urlTitle}/{id}",
                defaults: new { controller = "Blog", action = "Post" },
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
