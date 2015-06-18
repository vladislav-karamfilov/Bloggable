namespace Bloggable.Web.Config
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Integration.Web.Mvc;

    public static class SimpleInjectorConfig
    {
        public static Container RegisterServices(Assembly mvcControllersAssembly)
        {
            var container = new Container();

            container.RegisterPackages(new[] { Assembly.GetExecutingAssembly() });

            container.RegisterMvcControllers(mvcControllersAssembly);

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            return container;
        }
    }
}