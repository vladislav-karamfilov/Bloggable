namespace Bloggable.Services.Administration.Base
{
    using System.Collections.Generic;

    using Bloggable.Data.Contracts;
    using Bloggable.Services.Administration.Contracts;

    public class AuditInfoAdministrationService<TAuditInfo> : IAdministrationService<TAuditInfo>
        where TAuditInfo : class, IAuditInfo
    {
        private readonly IRepository<TAuditInfo> entities;

        public AuditInfoAdministrationService(IRepository<TAuditInfo> entities)
        {
            this.entities = entities;
        }

        public IEnumerable<TAuditInfo> Read()
        {
            return this.entities.All();
        }

        public TAuditInfo Get(object id)
        {
            return this.entities.GetById(id);
        }

        public void Create(TAuditInfo entity)
        {
            this.entities.Add(entity);
            this.entities.SaveChanges();
        }

        public void Update(TAuditInfo entity)
        {
            this.entities.Update(entity);
            this.entities.SaveChanges();
        }

        public void Delete(object id)
        {
            this.entities.Delete(id);
            this.entities.SaveChanges();
        }
    }
}
