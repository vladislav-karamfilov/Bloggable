namespace Bloggable.Services.Administration.Base
{
    using System.Collections.Generic;

    using Bloggable.Data.Contracts;
    using Bloggable.Data.Contracts.Repositories;
    using Bloggable.Services.Administration.Contracts;

    public class DeletableEntityAdministrationService<TDeletableEntity> :
            AdministrationService<TDeletableEntity>,
            IDeletableEntityAdministrationService<TDeletableEntity>
        where TDeletableEntity : class, IDeletableEntity
    {
        private readonly IDeletableEntityRepository<TDeletableEntity> entities;

        public DeletableEntityAdministrationService(IDeletableEntityRepository<TDeletableEntity> entities)
            : base(entities)
        {
            this.entities = entities;
        }

        public virtual IEnumerable<TDeletableEntity> ReadWithDeleted()
        {
            return this.entities.AllWithDeleted();
        }

        public virtual void HardDelete(object id)
        {
            this.entities.HardDelete(id);
            this.entities.SaveChanges();
        }

        public void HardDelete(TDeletableEntity entity)
        {
            this.entities.HardDelete(entity);
            this.entities.SaveChanges();
        }
    }
}
