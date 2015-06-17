namespace Bloggable.Data.Contracts
{
    using System.ComponentModel.DataAnnotations;

    public abstract class IdentifiableAuditInfo<TKey> : AuditInfo, IIdentifiable<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
