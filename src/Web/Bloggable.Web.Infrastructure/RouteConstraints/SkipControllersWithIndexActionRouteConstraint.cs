namespace Bloggable.Web.Infrastructure.RouteConstraints
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Bloggable.Common.Helpers;

    public class SkipControllersWithIndexActionRouteConstraint : IRouteConstraint
    {
        private const string ControllerSuffix = "Controller";
        private const string IndexActionName = "Index";

        private readonly Assembly controllersAssembly;

        private IEnumerable<string> controllersWithIndexAction;

        public SkipControllersWithIndexActionRouteConstraint(Assembly controllersAssembly)
        {
            this.controllersAssembly = controllersAssembly;
        }

        private IEnumerable<string> ContollersWithIndexAction => 
            this.controllersWithIndexAction ?? 
            (this.controllersWithIndexAction = ReflectionHelper
                .GetSubClasses<Controller>(this.controllersAssembly)
                .Where(t => t.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                    .Any(m =>
                        (m.Name.Equals(IndexActionName, StringComparison.InvariantCultureIgnoreCase) ||
                            (m.GetCustomAttribute<ActionNameAttribute>()?.Name.Equals(IndexActionName, StringComparison.InvariantCultureIgnoreCase) ?? false)) &&
                        m.GetCustomAttribute<NonActionAttribute>() == null))
                .Select(t => t.Name.Substring(0, t.Name.Length - ControllerSuffix.Length)));

        public bool Match(
            HttpContextBase httpContext,
            Route route,
            string parameterName,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            var parameterValue = values[parameterName] as string;

            var match = this.ContollersWithIndexAction.All(controller => !controller.Equals(parameterValue, StringComparison.InvariantCultureIgnoreCase));
            return match;
        }
    }
}
