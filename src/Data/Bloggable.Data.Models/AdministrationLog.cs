namespace Bloggable.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Common.Constants;
    using Bloggable.Data.Contracts;

    public class AdministrationLog : IdentifiableAuditInfo<long>
    {
        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        [MaxLength(AdministrationLogValidationConstants.IpAddressMaxLength)]
        public string IpAddress { get; set; }

        [Required]
        [MaxLength(AdministrationLogValidationConstants.RequestTypeMaxLength)]
        public string RequestType { get; set; }

        [Required]
        [MaxLength(ContentHolderValidationConstants.UrlMaxLength)]
        public string Url { get; set; }

        [MaxLength(AdministrationLogValidationConstants.PostParamsMaxLength)]
        public string PostParams { get; set; }
    }
}
