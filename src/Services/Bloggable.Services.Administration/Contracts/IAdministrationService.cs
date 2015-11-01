namespace Bloggable.Services.Administration.Contracts
{
    using System.Linq;

    using Bloggable.Data.Contracts;
    using Bloggable.Services.Common;

    public interface IAdministrationService<TEntity> : IService
        where TEntity : IEntity
    {
        IQueryable<TEntity> Read();

        TEntity Get(object id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entity);
    }
}
