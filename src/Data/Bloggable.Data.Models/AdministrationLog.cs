namespace Bloggable.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Data.Contracts;

    public class AdministrationLog : IdentifiableAuditInfo<long>
    {
        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public string IpAddress { get; set; }

        [Required]
        public string RequestType { get; set; }

        [Required]
        public string Url { get; set; }

        public string PostParams { get; set; }
    }
}
