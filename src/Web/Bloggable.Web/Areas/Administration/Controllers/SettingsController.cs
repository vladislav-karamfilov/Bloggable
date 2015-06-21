namespace Bloggable.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Bloggable.Services.Administration.Contracts;
    using Bloggable.Web.Areas.Administration.Controllers.Base;

    using Kendo.Mvc.UI;

    using EntityModel = Bloggable.Data.Models.Setting;
    using ViewModel = Bloggable.Web.Models.Administration.Settings.ViewModels.SettingGridViewModel;

    public class SettingsController : KendoGridAdministrationController<EntityModel, ViewModel>
    {
        public SettingsController(IAdministrationService<EntityModel> administrationService)
            : base(administrationService)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            this.CreateEntity(model);
            return this.GridOperation(request, model);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            this.UpdateEntity(model.Id, model);
            return this.GridOperation(request, model);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            this.DestroyEntity(model.Id);
            return this.GridOperation(request, model);
        }
    }
}