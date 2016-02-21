namespace Bloggable.Data.Helpers
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using Bloggable.Data.Contracts.Helpers;

    public class EfEntityKeyTypesProvider : IEntityKeyTypesProvider
    {
        private readonly DbContext dbContext;

        public EfEntityKeyTypesProvider(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            this.dbContext = dbContext;
        }

        public Type[] GetKeyTypes(Type entityType)
        {
            if (entityType == null)
            {
                throw new ArgumentNullException(nameof(entityType));
            }

            var metadata = ((IObjectContextAdapter)this.dbContext).ObjectContext.MetadataWorkspace;

            // Get the mapping between CLR types and metadata OSpace
            var objectItemCollection = (ObjectItemCollection)metadata.GetItemCollection(DataSpace.OSpace);

            // Get metadata for given CLR type
            var entityMetadata = metadata
                .GetItems<EntityType>(DataSpace.OSpace)
                .SingleOrDefault(e => objectItemCollection.GetClrType(e) == entityType);

            var keyTypes = entityMetadata?.KeyProperties.Select(kp => kp.PrimitiveType.ClrEquivalentType).ToArray();
            return keyTypes;
        }
    }
}
