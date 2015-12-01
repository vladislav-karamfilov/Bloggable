namespace Bloggable.Web
{
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Bloggable.Common.Constants;
    using Bloggable.Common.Mapping;
    using Bloggable.Web.Config;

    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            DataConfig.ConfigureDataStore();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewEngineConfig.RegisterViewEngines(ViewEngines.Engines);
            AutoMapperConfig.RegisterMappings(Assembly.Load(AssemblyConstants.WebModels), Assembly.Load(AssemblyConstants.WebInfrastructure));
            
            MvcHandler.DisableMvcResponseHeader = true;
        }
    }
}
