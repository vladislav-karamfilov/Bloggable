namespace Bloggable.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Common.Constants;
    using Bloggable.Data.Models.Base;

    public class Referral : IdentifiableAuditInfo<int>
    {
        [Required]
        [MinLength(ReferralValidationConstants.NameMinLength)]
        [MaxLength(ReferralValidationConstants.NameMaxLength)]
        public string Name { get; set; }

        [MaxLength(ReferralValidationConstants.DescriptionMaxLength)]
        public string Description { get; set; }
    }
}
