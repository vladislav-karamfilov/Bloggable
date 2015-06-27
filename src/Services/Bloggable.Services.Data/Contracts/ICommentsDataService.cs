namespace Bloggable.Services.Data.Contracts
{
    using System.Linq;

    using Bloggable.Data.Models;

    public interface ICommentsDataService
    {
        void AddCommentForPost(int postId, string content, string authorId);

        IQueryable<Comment> ByPost(int postId, bool includeDeleted = false);
    }
}
