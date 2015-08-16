namespace Bloggable.Web.Models.Comments.InputModels
{
    using Bloggable.Common.Mapping;
    using Bloggable.Data.Models;

    public class CreateCommentInputModel : BaseCommentInputModel, IMapTo<Comment>
    {
        public int PostId { get; set; }
    }
}
