namespace Bloggable.Web.Infrastructure.ModelBinders
{
    using System.Web.Mvc;

    using Bloggable.Data.Contracts;
    using Bloggable.Data.Contracts.Repositories;

    public class EntityModelBinder<TEntity> : IModelBinder
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> entities;

        public EntityModelBinder(IRepository<TEntity> entities)
        {
            this.entities = entities;
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue("id");

            object entityId = value?.AttemptedValue;

            if (entityId != null)
            {
                var entity = this.entities.GetById(entityId);
                return entity;
            }

            return null;
        }
    }
}
