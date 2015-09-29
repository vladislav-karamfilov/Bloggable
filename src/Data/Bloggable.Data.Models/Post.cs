namespace Bloggable.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Common.Constants;

    public class Post : ContentHolder
    {
        private ICollection<Tag> tags;

        public Post()
        {
            this.tags = new HashSet<Tag>();
        }

        [MinLength(ContentHolderValidationConstants.TitleMinLength)]
        [MaxLength(ContentHolderValidationConstants.TitleMaxLength)]
        public string SubTitle { get; set; }

        [MaxLength(ContentHolderValidationConstants.SummaryMaxLength)]
        public string Summary { get; set; }

        // TODO: Separate to two properties
        [MinLength(ContentHolderValidationConstants.UrlMinLength)]
        [MaxLength(ContentHolderValidationConstants.UrlMaxLength)]
        public string ImageOrVideoUrl { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}