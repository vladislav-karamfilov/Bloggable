﻿namespace Bloggable.Data.Repositories.Base
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Bloggable.Data.Contracts;

    public class EfDeletableEntityRepository<T> : EfRepository<T>, IDeletableEntityRepository<T>
        where T : class, IDeletableEntity
    {
        public EfDeletableEntityRepository(DbContext context)
            : base(context)
        {
        }

        public override IQueryable<T> All()
        {
            return base.All().Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return base.All();
        }

        public void HardDelete(T entity)
        {
            base.Delete(entity);
        }

        public void HardDelete(object id)
        {
            base.Delete(id);
        }

        public override void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            this.Update(entity);
        }
    }
}
