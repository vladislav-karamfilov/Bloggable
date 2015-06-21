namespace Bloggable.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Common.Constants;
    using Bloggable.Data.Contracts;

    public class Comment : IdentifiableDeletableEntity<int>
    {
        [Required]
        [MinLength(CommentValidationConstants.ContentMinLength)]
        [MaxLength(CommentValidationConstants.ContentMaxLength)]
        public string Content { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
