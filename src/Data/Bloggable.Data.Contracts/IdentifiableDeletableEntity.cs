namespace Bloggable.Data.Contracts
{
    using System.ComponentModel.DataAnnotations;

    public abstract class IdentifiableDeletableEntity<TKey> : DeletableEntity
    {
        [Key]
        public TKey Id { get; set; }
    }
}
