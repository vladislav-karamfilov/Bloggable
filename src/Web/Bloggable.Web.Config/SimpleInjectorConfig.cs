namespace Bloggable.Web.Config
{
    using System.Reflection;
    using System.Web.Mvc;

    using Bloggable.Web.Config.Identity;

    using SimpleInjector;
    using SimpleInjector.Diagnostics;
    using SimpleInjector.Integration.Web.Mvc;

    public static class SimpleInjectorConfig
    {
        public static Container RegisterServices(Assembly mvcControllersAssembly)
        {
            var container = new Container();

            container.RegisterPackages(new[] { Assembly.GetExecutingAssembly() });

            container.RegisterMvcControllers(mvcControllersAssembly);

            var applicationSignInManager = container.GetRegistration(typeof(ApplicationSignInManager)).Registration;
            applicationSignInManager.SuppressDiagnosticWarning(
                DiagnosticType.DisposableTransientComponent, 
                "ASP.NET takes care of ApplicationSignInManager objects' disposal.");

            var applicationUserManager = container.GetRegistration(typeof(ApplicationUserManager)).Registration;
            applicationUserManager.SuppressDiagnosticWarning(
                DiagnosticType.DisposableTransientComponent,
                "ASP.NET takes care of ApplicationUserManager objects' disposal.");

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            return container;
        }
    }
}