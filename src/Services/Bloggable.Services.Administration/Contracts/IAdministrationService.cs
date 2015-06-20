namespace Bloggable.Services.Administration.Contracts
{
    using System.Linq;

    using Bloggable.Data.Contracts;

    public interface IAdministrationService<TEntity>
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
