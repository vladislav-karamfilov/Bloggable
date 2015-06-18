namespace Bloggable.Services.Administration.Contracts
{
    using System.Collections.Generic;

    using Bloggable.Data.Contracts;

    public interface IAdministrationService<TEntity>
        where TEntity : IEntity
    {
        IEnumerable<TEntity> Read();

        TEntity Get(object id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(object id);
    }
}
