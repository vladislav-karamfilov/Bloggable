namespace Bloggable.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Common.Constants;
    using Bloggable.Data.Contracts;

    public abstract class ContentHolder : IdentifiableDeletableEntity<int>
    {
        private ICollection<Tag> tags;

        protected ContentHolder()
        {
            this.tags = new HashSet<Tag>();
        }

        [Required]
        [MinLength(ContentHolderValidationConstants.TitleMinLength)]
        [MaxLength(ContentHolderValidationConstants.TitleMaxLength)]
        public string Title { get; set; }

        [MinLength(ContentHolderValidationConstants.TitleMinLength)]
        [MaxLength(ContentHolderValidationConstants.TitleMaxLength)]
        public string SubTitle { get; set; }

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

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}
