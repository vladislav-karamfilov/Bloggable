namespace Bloggable.Services.Administration.Contracts
{
    using System.Linq;

    using Bloggable.Data.Contracts;

    public interface IDeletableEntityAdministrationService<TDeletableEntity> : IAdministrationService<TDeletableEntity>
        where TDeletableEntity : IDeletableEntity
    {
        IQueryable<TDeletableEntity> ReadWithDeleted();

        void HardDelete(object id);

        void HardDelete(TDeletableEntity entity);
    }
}
