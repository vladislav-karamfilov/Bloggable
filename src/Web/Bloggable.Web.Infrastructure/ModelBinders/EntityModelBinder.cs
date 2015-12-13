namespace Bloggable.Web.Infrastructure.ModelBinders
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Bloggable.Data.Contracts;
    using Bloggable.Data.Contracts.Helpers.Contracts;
    using Bloggable.Data.Contracts.Repositories;

    public class EntityModelBinder<TEntity> : IModelBinder
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> entities;
        private readonly IEntityKeyTypesProvider entityKeyTypesProvider;

        public EntityModelBinder(IRepository<TEntity> entities, IEntityKeyTypesProvider entityKeyTypesProvider)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            if (entityKeyTypesProvider == null)
            {
                throw new ArgumentNullException(nameof(entityKeyTypesProvider));
            }

            this.entities = entities;
            this.entityKeyTypesProvider = entityKeyTypesProvider;
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue("id");

            if (value != null)
            {
                var entityKeyTypes = this.entityKeyTypesProvider.GetKeyTypes(typeof(TEntity));

                if (entityKeyTypes?.Length > 0)
                {
                    var entityId = ConvertToSpecifiedTypes(value, entityKeyTypes);
                    if (entityId?.Length > 0)
                    {
                        var entity = this.entities.GetById(entityId);
                        return entity;
                    }
                }
            }

            return null;
        }

        private static object[] ConvertToSpecifiedTypes(ValueProviderResult valueToConvert, IReadOnlyList<Type> types)
        {
            if (valueToConvert.RawValue != null && types.Count > 0)
            {
                var rawValueAsArray = valueToConvert.RawValue as Array;
                if (rawValueAsArray == null)
                {
                    if (types.Count == 1)
                    {
                        return new[] { valueToConvert.ConvertTo(types[0]) };
                    }
                }
                else if (rawValueAsArray.Length == types.Count)
                {
                    var values = new object[types.Count];
                    for (var i = 0; i < rawValueAsArray.Length; i++)
                    {
                        var currentRawValue = rawValueAsArray.GetValue(i);
                        var currentValue = new ValueProviderResult(currentRawValue, currentRawValue.ToString(), null);
                        values[i] = currentValue.ConvertTo(types[i]);
                    }

                    return values;
                }
            }

            return null;
        }
    }
}
