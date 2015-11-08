namespace Bloggable.Data.Contracts.Helpers.Contracts
{
    using System;

    public interface IEntityKeyTypesProvider
    {
        Type[] GetKeyTypes(Type entityType);
    }
}
