namespace Bloggable.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Common.Constants;

    public class Post : ContentHolder
    {
        private ICollection<Comment> comments;

        public Post()
        {
            this.comments = new HashSet<Comment>();
        }

        [MaxLength(ContentHolderValidationConstants.SummaryMaxLength)]
        public string Summary { get; set; }

        // TODO: Separate to two properties
        [MinLength(ContentHolderValidationConstants.UrlMinLength)]
        [MaxLength(ContentHolderValidationConstants.UrlMaxLength)]
        public string ImageOrVideoUrl { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}