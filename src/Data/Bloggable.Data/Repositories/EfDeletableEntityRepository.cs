namespace Bloggable.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Bloggable.Data.Contracts;
    using Bloggable.Data.Contracts.Repositories;

    public class EfDeletableEntityRepository<T> : EfRepository<T>, IDeletableEntityRepository<T>
        where T : class, IDeletableEntity
    {
        public EfDeletableEntityRepository(DbContext context)
            : base(context)
        {
        }

        public override IQueryable<T> All() => base.All().Where(x => !x.IsDeleted);

        public IQueryable<T> AllWithDeleted() => base.All();

        public void HardDelete(T entity)
        {
            base.Delete(entity);
        }

        public void HardDelete(params object[] id)
        {
            base.Delete(id);
        }

        public override void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            this.Update(entity);
        }

        public override void Delete(params object[] id)
        {
            var entity = this.GetById(id);
            if (entity != null)
            {
                this.Delete(entity);
            }
        }
    }
}
