namespace Bloggable.Services.Administration.Base
{
    using System.Collections.Generic;

    using Bloggable.Data.Contracts;
    using Bloggable.Services.Administration.Contracts;

    public class AdministrationService<TEntity> : IAdministrationService<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> entities;

        public AdministrationService(IRepository<TEntity> entities)
        {
            this.entities = entities;
        }

        public virtual IEnumerable<TEntity> Read()
        {
            return this.entities.All();
        }

        public virtual TEntity Get(object id)
        {
            return this.entities.GetById(id);
        }

        public virtual void Create(TEntity entity)
        {
            this.entities.Add(entity);
            this.entities.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            this.entities.Update(entity);
            this.entities.SaveChanges();
        }

        public virtual void Delete(object id)
        {
            this.entities.Delete(id);
            this.entities.SaveChanges();
        }
    }
}
