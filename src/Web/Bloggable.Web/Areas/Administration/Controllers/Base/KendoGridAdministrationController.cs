namespace Bloggable.Web.Areas.Administration.Controllers.Base
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Bloggable.Data.Contracts;
    using Bloggable.Services.Administration.Contracts;
    using Bloggable.Web.Infrastructure.Extensions;
    using Bloggable.Web.Models.Administration;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public abstract class KendoGridAdministrationController<TEntity, TViewModel> : AdministrationController
        where TEntity : class, IAuditInfo
        where TViewModel : AdministrationGridViewModel
    {
        protected KendoGridAdministrationController(IAdministrationService<TEntity> administrationService)
        {
            this.AdministrationService = administrationService;
        }

        protected IAdministrationService<TEntity> AdministrationService { get; }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            return this.JsonWithoutReferenceLoop(this.GetData().ToDataSourceResult(request));
        }

        protected virtual IEnumerable<TViewModel> GetData()
        {
            return this.AdministrationService.Read().Project().To<TViewModel>();
        }

        protected virtual TEntity CreateEntity(TViewModel model)
        {
            TEntity entity = null;

            if (model != null && this.ModelState.IsValid)
            {
                entity = Mapper.Map<TEntity>(model);
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
                    Mapper.Map(model, entity);
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

        protected ActionResult GridOperation([DataSourceRequest]DataSourceRequest request, object model)
        {
            return this.JsonWithoutReferenceLoop(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}