using System.ComponentModel.DataAnnotations;

namespace Bloggable.Web.Models.Comments.InputModels
{
    public abstract class BaseCommentInputModel
    {
        public string Content { get; set; }

        [ScaffoldColumn(false)]
        public string AuthorId { get; set; }
    }
}
