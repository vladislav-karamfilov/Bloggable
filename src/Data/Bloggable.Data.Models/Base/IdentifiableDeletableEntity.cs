namespace Bloggable.Data.Models.Base
{
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Data.Contracts;

    public abstract class IdentifiableDeletableEntity<TKey> : DeletableEntity, IIdentifiable<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
