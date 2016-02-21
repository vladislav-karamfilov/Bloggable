namespace Bloggable.Data.Models.Base
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using Bloggable.Data.Contracts;

    public abstract class DeletableEntity : AuditInfo, IDeletableEntity
    {
        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
