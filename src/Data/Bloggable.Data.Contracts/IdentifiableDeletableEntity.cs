namespace Bloggable.Data.Contracts
{
    using System.ComponentModel.DataAnnotations;

    public abstract class IdentifiableDeletableEntity<TKey> : DeletableEntity, IIdentifiable<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
