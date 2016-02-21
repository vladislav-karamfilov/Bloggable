namespace Bloggable.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Common.Constants;
    using Bloggable.Data.Contracts.DataAnnotations;
    using Bloggable.Data.Models.Base;

    public class Feedback : IdentifiableAuditInfo<int>
    {
        [MinLength(ContentHolderValidationConstants.TitleMinLength)]
        [MaxLength(ContentHolderValidationConstants.TitleMaxLength)]
        public string Subject { get; set; }

        [Required]
        [MinLength(ContentHolderValidationConstants.ContentMinLength)]
        [MaxLength(ContentHolderValidationConstants.ContentMaxLength)]
        public string Content { get; set; }

        [IsUnicode(false)]
        [MinLength(UserValidationConstants.EmailMinLength)]
        [MaxLength(UserValidationConstants.EmailMaxLength)]
        public string Email { get; set; }

        [MinLength(UserValidationConstants.NameMinLength)]
        [MaxLength(UserValidationConstants.NameMaxLength)]
        public string Name { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
