namespace Bloggable.Data.Repositories.Base
{
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
    }
}
