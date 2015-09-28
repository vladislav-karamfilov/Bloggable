namespace Bloggable.Web
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Bloggable.Common.Constants;
    using Bloggable.Common.Mapping;
    using Bloggable.Data;
    using Bloggable.Data.Migrations;
    using Bloggable.Web.Config;

    using BrockAllen.CookieTempData;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BloggableDbContext, DefaultMigrationConfiguration>(true));

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewEngineConfig.RegisterViewEngines(ViewEngines.Engines);
            AutoMapperConfig.RegisterMappings(Assembly.Load(AssemblyConstants.WebModels), Assembly.Load(AssemblyConstants.WebInfrastructure));

            var currentControllerFactory = ControllerBuilder.Current.GetControllerFactory();
            ControllerBuilder.Current.SetControllerFactory(new CookieTempDataControllerFactory(currentControllerFactory));

            MvcHandler.DisableMvcResponseHeader = true;
        }
    }
}
