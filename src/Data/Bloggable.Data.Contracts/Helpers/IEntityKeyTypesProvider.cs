namespace Bloggable.Data.Contracts.Helpers
{
    using System;

    public interface IEntityKeyTypesProvider
    {
        Type[] GetKeyTypes(Type entityType);
    }
}
