namespace Bloggable.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Data.Contracts;

    public class Feedback : IdentifiableAuditInfo<int>
    {
        public string Subject { get; set; }

        [Required]
        public string Content { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
