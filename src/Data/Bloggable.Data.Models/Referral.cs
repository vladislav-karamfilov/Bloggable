namespace Bloggable.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Data.Contracts;

    public class Referral : IdentifiableAuditInfo<int>
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
