﻿namespace Bloggable.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    
    using Bloggable.Services.Administration.Contracts;
    using Bloggable.Services.Common.Mapping.Contracts;
    using Bloggable.Web.Areas.Administration.Controllers.Base;
    using Bloggable.Web.Infrastructure.Extensions;

    using Kendo.Mvc.UI;

    using EntityModel = Bloggable.Data.Models.Page;
    using PublicPagesController = Bloggable.Web.Controllers.PagesController;
    using ViewModel = Bloggable.Web.Models.Administration.Pages.ViewModels.PageGridViewModel;

    public class PagesController : KendoGridAdministrationController<EntityModel, ViewModel>
    {
        private readonly IPagesAdministrationService administrationService;

        public PagesController(IPagesAdministrationService administrationService, IMappingService mappingService)
            : base(administrationService, mappingService)
        {
            this.administrationService = administrationService;
        }

        [HttpGet]
        public ActionResult Index() => this.View();

        [HttpGet]
        public ActionResult Create() => this.View(new ViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")]ViewModel model)
        {
            var entity = this.CreateEntity(model);

            if (entity != null)
            {
                return this.RedirectToAction(c => c.Index()).WithSuccessAlert("Successfully created page.");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            var entity = this.administrationService.Get(id);

            if (entity != null)
            {
                var model = this.MappingService.Map<ViewModel>(entity);
                return this.View(model);
            }

            return this.RedirectToAction(c => c.Index()).WithErrorAlert("Page not found.");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ViewModel model)
        {
            var updatedEntity = this.FindAndUpdateEntity(model.Id, model);

            if (updatedEntity != null)
            {
                return this.RedirectToAction(c => c.Index()).WithSuccessAlert("Page updated successfully.");
            }

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            this.DestroyEntity(model.Id);
            return this.GridOperation(request, model);
        }
        
        public ActionResult Show(int? id)
        {
            var page = this.administrationService.Get(id);

            if (page == null)
            {
                return this.RedirectToAction(c => c.Index()).WithErrorAlert("Page not found.");
            }

            if (page.IsDeleted)
            {
                return this.RedirectToAction(c => c.Index()).WithErrorAlert("The page was deleted.");
            }

            return this.RedirectToAction<PublicPagesController>(c => c.Page(page.Permalink));
        }

        public ActionResult IsAvailablePermalink(string permalink, string initialPermalink = null)
        {
            var isAvailablePermalink = this.administrationService.IsAvailablePagePermalink(permalink, initialPermalink);
            return this.Json(isAvailablePermalink, JsonRequestBehavior.AllowGet);
        }
    }
}