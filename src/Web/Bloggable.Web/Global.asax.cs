namespace Bloggable.Web
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Bloggable.Common.Constants;
    using Bloggable.Common.Mapping;
    using Bloggable.Web.Config;

    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules", 
        "SA1649:File name must match first type name", 
        Justification = "Global.asax.cs is required for ASP.NET apps to start correctly.")]
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DataConfig.ConfigureData();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewEngineConfig.RegisterViewEngines(ViewEngines.Engines);
            AutoMapperConfig.RegisterMappings(Assembly.Load(AssemblyConstants.WebModels), Assembly.Load(AssemblyConstants.WebInfrastructure));
            
            MvcHandler.DisableMvcResponseHeader = true;
        }
    }
}
