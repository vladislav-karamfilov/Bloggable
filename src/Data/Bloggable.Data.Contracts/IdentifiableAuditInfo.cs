namespace Bloggable.Data.Contracts
{
    using System.ComponentModel.DataAnnotations;

    public abstract class IdentifiableAuditInfo<TKey> : AuditInfo
    {
        [Key]
        public TKey Id { get; set; }
    }
}
