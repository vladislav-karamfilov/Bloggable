namespace Bloggable.Web.Infrastructure.Extensions
{
    using System.Web.Routing;

    public static class RouteExtensions
    {
        public static Route WithConstraints(this Route route, string key, IRouteConstraint constraint)
        {
            route.Constraints.Add(key, constraint);
            return route;
        }
    }
}
