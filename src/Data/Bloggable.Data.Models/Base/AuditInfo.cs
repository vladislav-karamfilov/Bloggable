namespace Bloggable.Data.Models.Base
{
    using System;

    using Bloggable.Data.Contracts;

    public abstract class AuditInfo : IAuditInfo
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
