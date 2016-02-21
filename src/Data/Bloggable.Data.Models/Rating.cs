namespace Bloggable.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    
    using Bloggable.Data.Models.Base;

    public class Rating : IdentifiableAuditInfo<int>
    {
        public byte Value { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
