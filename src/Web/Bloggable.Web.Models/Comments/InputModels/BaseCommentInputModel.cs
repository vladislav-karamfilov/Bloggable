namespace Bloggable.Web.Models.Comments.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Common.Constants;

    public abstract class BaseCommentInputModel
    {
        [Required]
        [StringLength(
            CommentValidationConstants.ContentMaxLength,
            MinimumLength = CommentValidationConstants.ContentMinLength,
            ErrorMessage = "Comment content must be between {2} and {1} characters long.")]
        public string Content { get; set; }
    }
}
