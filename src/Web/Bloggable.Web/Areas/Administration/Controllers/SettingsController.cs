namespace Bloggable.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using Bloggable.Common.Constants;
    using Bloggable.Services.Administration.Contracts;
    using Bloggable.Services.Common.Cache.Contracts;
    using Bloggable.Web.Areas.Administration.Controllers.Base;
    using Bloggable.Web.Infrastructure.Extensions;

    using Kendo.Mvc.UI;

    using EntityModel = Bloggable.Data.Models.Setting;
    using ViewModel = Bloggable.Web.Models.Administration.Settings.ViewModels.SettingGridViewModel;

    public class SettingsController : KendoGridAdministrationController<EntityModel, ViewModel>
    {
        private readonly ISettingsAdministrationService administrationService;
        private readonly ICacheService cache;

        public SettingsController(ISettingsAdministrationService administrationService, ICacheService cache)
            : base(administrationService)
        {
            this.administrationService = administrationService;
            this.cache = cache;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (this.administrationService.IsAvailableSettingKey(model.Id))
            {
                this.CreateEntity(model);
            }
            else
            {
                this.ModelState.AddModelError<ViewModel>(m => m.Id, "A setting with this key already exists...");
            }

            return this.GridOperation(request, model);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            this.FindAndUpdateEntity(model.Id, model);
            return this.GridOperation(request, model);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            this.DestroyEntity(model.Id);
            return this.GridOperation(request, model);
        }

        [HttpPost]
        public ActionResult RefreshSettingsInCache()
        {
            this.cache.Remove(CacheConstants.Settings);
            return this.EmptyResult();
        }
    }
}