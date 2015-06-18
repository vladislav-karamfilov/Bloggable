namespace Bloggable.Services.Administration.Contracts
{
    using System.Collections.Generic;

    using Bloggable.Data.Contracts;

    public interface IAdministrationService<T>
        where T : IEntity
    {
        IEnumerable<T> Read();

        T Get(object id);

        void Create(T entity);

        void Update(T entity);

        void Delete(object id);
    }
}
