namespace Bloggable.Services.Administration.Contracts
{
    using System.Collections.Generic;

    using Bloggable.Data.Contracts;

    public interface IDeletableEntityAdministrationService<TDeletableEntity> : IAdministrationService<TDeletableEntity>
        where TDeletableEntity : IDeletableEntity
    {
        IEnumerable<TDeletableEntity> ReadWithDeleted();

        void HardDelete(object id);
    }
}
