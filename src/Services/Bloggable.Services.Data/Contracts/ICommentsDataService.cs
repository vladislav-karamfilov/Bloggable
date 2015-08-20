namespace Bloggable.Services.Data.Contracts
{
    using System.Linq;

    using Bloggable.Data.Models;
    using Bloggable.Services.Common;

    public interface ICommentsDataService : IService
    {
        Comment GetById(int id);

        Comment AddCommentForPost(int postId, string content, string authorId);

        Comment UpdateComment(object commentId, string newContent);

        IQueryable<Comment> GetByPost(int postId, bool includeDeleted = false);

        int GetCountByPost(int postId, bool includeDeleted = false);

        object GetAuthorId(object commentId, bool includeDeleted = false);
    }
}
