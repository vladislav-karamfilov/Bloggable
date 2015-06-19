namespace Bloggable.Web.Areas.Administration.Controllers.Base
{
    using System.Collections;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public abstract class KendoGridAdministrationController : AdministrationController
    {
        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var data = this.GetData();
            return this.Json(data.ToDataSourceResult(request));
        }

        protected abstract IEnumerable GetData();
        
        protected ActionResult GridOperation([DataSourceRequest]DataSourceRequest request, object model)
        {
            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}