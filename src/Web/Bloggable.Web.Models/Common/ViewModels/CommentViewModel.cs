namespace Bloggable.Web.Models.Common.ViewModels
{
    using Bloggable.Common.Mapping;
    using Bloggable.Data.Models;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string AuthorUserName { get; set; }

        public string Content { get; set; }
    }
}
