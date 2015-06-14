namespace Bloggable.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Data.Contracts;

    public class SearchTerm : IdentifiableAuditInfo<int>
    {
        [Required]
        public string Content { get; set; }

        public int SearchCount { get; set; }
    }
}
