namespace Bloggable.Web.Areas.Administration.Controllers.Base
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Bloggable.Data.Contracts;
    using Bloggable.Services.Administration.Contracts;
    using Bloggable.Services.Common.Mapping.Contracts;
    using Bloggable.Web.Infrastructure.Extensions;
    using Bloggable.Web.Models.Administration;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public abstract class KendoGridAdministrationController<TEntity, TViewModel> : AdministrationController
        where TEntity : class, IAuditInfo
        where TViewModel : AdministrationGridViewModel
    {
        protected KendoGridAdministrationController(IAdministrationService<TEntity> administrationService, IMappingService mappingService)
        {
            if (administrationService == null)
            {
                throw new ArgumentNullException(nameof(administrationService));
            }

            if (mappingService == null)
            {
                throw new ArgumentNullException(nameof(mappingService));
            }

            this.AdministrationService = administrationService;
            this.MappingService = mappingService;
        }

        protected IAdministrationService<TEntity> AdministrationService { get; }

        protected IMappingService MappingService { get; }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request) =>
            this.JsonWithoutReferenceLoop(this.GetData().ToDataSourceResult(request));

        protected virtual IEnumerable<TViewModel> GetData() =>
            this.MappingService.MapCollection<TViewModel>(this.AdministrationService.Read());

        protected virtual TEntity CreateEntity(TViewModel model)
        {
            TEntity entity = null;

            if (model != null && this.ModelState.IsValid)
            {
                entity = this.MappingService.Map<TEntity>(model);
                this.AdministrationService.Create(entity);
                model.CreatedOn = entity.CreatedOn;
            }

            return entity;
        }

        protected virtual TEntity FindAndUpdateEntity(object id, TViewModel model)
        {
            TEntity entity = null;

            if (model != null && this.ModelState.IsValid)
            {
                entity = this.AdministrationService.Get(id);
                if (entity != null)
                {
                    this.MappingService.Map(model, entity);
                    this.AdministrationService.Update(entity);
                    model.ModifiedOn = entity.ModifiedOn;
                }
            }

            return entity;
        }

        protected virtual void DestroyEntity(object id)
        {
            if (this.ModelState.IsValid)
            {
                this.AdministrationService.Delete(id);
            }
        }

        protected ActionResult GridOperation([DataSourceRequest]DataSourceRequest request, object model) =>
            this.JsonWithoutReferenceLoop(new[] { model }.ToDataSourceResult(request, this.ModelState));
    }
}