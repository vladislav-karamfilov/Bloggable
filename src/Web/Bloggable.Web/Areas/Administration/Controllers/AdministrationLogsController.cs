namespace Bloggable.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Bloggable.Services.Administration.Contracts;
    using Bloggable.Services.Common.Mapping.Contracts;
    using Bloggable.Web.Areas.Administration.Controllers.Base;

    using Kendo.Mvc.UI;

    using EntityModel = Bloggable.Data.Models.AdministrationLog;
    using ViewModel = Bloggable.Web.Models.Administration.AdministrationLogs.ViewModels.AdministrationLogGridViewModel;

    public class AdministrationLogsController : KendoGridAdministrationController<EntityModel, ViewModel>
    {
        public AdministrationLogsController(IAdministrationService<EntityModel> administrationService, IMappingService mappingService)
            : base(administrationService, mappingService)
        {
        }

        [HttpGet]
        public ActionResult Index() => this.View();

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            this.DestroyEntity(model.Id);
            return this.GridOperation(request, model);
        }
    }
}