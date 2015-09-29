namespace Bloggable.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Common.Constants;
    using Bloggable.Data.Contracts;

    public abstract class ContentHolder : IdentifiableDeletableEntity<int>
    {
        [Required]
        [MinLength(ContentHolderValidationConstants.TitleMinLength)]
        [MaxLength(ContentHolderValidationConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ContentHolderValidationConstants.ContentMinLength)]
        [MaxLength(ContentHolderValidationConstants.ContentMaxLength)]
        public string Content { get; set; }

        [MinLength(ContentHolderValidationConstants.MetaDescriptionMinLength)]
        [MaxLength(ContentHolderValidationConstants.MetaDescriptionMaxLength)]
        public string MetaDescription { get; set; }

        [MinLength(ContentHolderValidationConstants.MetaKeywordsMinLength)]
        [MaxLength(ContentHolderValidationConstants.MetaKeywordsMaxLength)]
        public string MetaKeywords { get; set; }
    }
}
