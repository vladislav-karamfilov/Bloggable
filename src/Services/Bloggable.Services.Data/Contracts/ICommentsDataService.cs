namespace Bloggable.Services.Data.Contracts
{
    using System.Linq;

    using Bloggable.Data.Models;
    using Bloggable.Services.Common;

    public interface ICommentsDataService : IService
    {
        void AddCommentForPost(int postId, string content, string authorId);

        void UpdateComment(object commentId, string newContent);

        IQueryable<Comment> ByPost(int postId, bool includeDeleted = false);

        object GetAuthorId(object commentId, bool includeDeleted = false);
    }
}
