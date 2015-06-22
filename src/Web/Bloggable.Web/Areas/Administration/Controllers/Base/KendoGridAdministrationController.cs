namespace Bloggable.Web.Areas.Administration.Controllers.Base
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Bloggable.Common.Constants;
    using Bloggable.Data.Contracts;
    using Bloggable.Services.Administration.Contracts;
    using Bloggable.Web.Models.Administration;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Newtonsoft.Json;

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
            var serializationSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var json = JsonConvert.SerializeObject(data.ToDataSourceResult(request), Formatting.None, serializationSettings);
            return this.Content(json, ContentTypeConstants.Json);
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

        protected virtual TEntity FindAndUpdateEntity(object id, TViewModel model)
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