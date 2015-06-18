namespace Bloggable.Services.Administration.Base
{
    using System.Collections.Generic;

    using Bloggable.Data.Contracts;
    using Bloggable.Services.Administration.Contracts;

    public class DeletableEntityAdministrationService<TDeletableEntity> : IDeletableEntityAdministrationService<TDeletableEntity>
        where TDeletableEntity : class, IDeletableEntity
    {
        private readonly IDeletableEntityRepository<TDeletableEntity> entities;

        public DeletableEntityAdministrationService(IDeletableEntityRepository<TDeletableEntity> entities)
        {
            this.entities = entities;
        }

        public IEnumerable<TDeletableEntity> Read()
        {
            return this.entities.All();
        }

        public IEnumerable<TDeletableEntity> ReadWithDeleted()
        {
            return this.entities.AllWithDeleted();
        }

        public TDeletableEntity Get(object id)
        {
            return this.entities.GetById(id);
        }

        public void Create(TDeletableEntity entity)
        {
            this.entities.Add(entity);
            this.entities.SaveChanges();
        }

        public void Update(TDeletableEntity entity)
        {
            this.entities.Update(entity);
            this.entities.SaveChanges();
        }

        public void Delete(object id)
        {
            this.entities.Delete(id);
            this.entities.SaveChanges();
        }

        public void HardDelete(object id)
        {
            this.entities.HardDelete(id);
            this.entities.SaveChanges();
        }
    }
}
