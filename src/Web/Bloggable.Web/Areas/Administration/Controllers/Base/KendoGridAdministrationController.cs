namespace Bloggable.Web.Areas.Administration.Controllers.Base
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Bloggable.Data.Contracts;
    using Bloggable.Services.Administration.Contracts;
    using Bloggable.Web.Models.Administration;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public abstract class KendoGridAdministrationController<TEntity, TViewModel> : AdministrationController
        where TEntity : class, IAuditInfo
        where TViewModel : AdministrationGridViewModel
    {
        private readonly IAdministrationService<TEntity> administrationService;

        protected KendoGridAdministrationController(IAdministrationService<TEntity> administrationService)
        {
            this.administrationService = administrationService;
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var data = this.GetData();
            return this.Json(data.ToDataSourceResult(request));
        }

        protected virtual IEnumerable<TViewModel> GetData()
        {
            return this.administrationService.Read().Project().To<TViewModel>();
        }

        protected virtual TEntity CreateEntity(TViewModel model)
        {
            TEntity entity = null;

            if (model != null && this.ModelState.IsValid)
            {
                entity = Mapper.Map<TEntity>(model);
                this.administrationService.Create(entity);
                model.CreatedOn = entity.CreatedOn;
            }

            return entity;
        }

        protected virtual TEntity UpdateEntity(object id, TViewModel model)
        {
            TEntity entity = null;

            if (model != null && this.ModelState.IsValid)
            {
                entity = this.administrationService.Get(id);
                if (entity != null)
                {
                    Mapper.Map(model, entity);
                    this.administrationService.Update(entity);
                    model.ModifiedOn = entity.ModifiedOn;
                }
            }

            return entity;
        }

        protected virtual void DestroyEntity(object id)
        {
            if (this.ModelState.IsValid)
            {
                this.administrationService.Delete(id);
            }
        }

        protected ActionResult GridOperation([DataSourceRequest]DataSourceRequest request, object model)
        {
            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}