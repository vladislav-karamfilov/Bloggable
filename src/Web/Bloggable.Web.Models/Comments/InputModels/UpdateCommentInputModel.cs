namespace Bloggable.Web.Models.Comments.InputModels
{
    using Bloggable.Common.Mapping;
    using Bloggable.Data.Models;

    public class UpdateCommentInputModel : BaseCommentInputModel, IMapFrom<Comment>, IMapTo<Comment>
    {
        public int Id { get; set; }
    }
}
