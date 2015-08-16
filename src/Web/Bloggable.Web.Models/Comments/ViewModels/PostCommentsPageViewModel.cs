namespace Bloggable.Web.Models.Comments.ViewModels
{
    using PagedList;

    public class PostCommentsPageViewModel
    {
        public int PostId { get; set; }

        public IPagedList<CommentViewModel> Comments { get; set; }
    }
}
