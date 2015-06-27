namespace Bloggable.Services.Data
{
    using System.Linq;

    using Bloggable.Data.Contracts.Repositories;
    using Bloggable.Data.Models;
    using Bloggable.Services.Data.Contracts;

    public class CommentsDataService : ICommentsDataService
    {
        private readonly IDeletableEntityRepository<Comment> comments;

        public CommentsDataService(IDeletableEntityRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public void AddCommentForPost(int postId, string content, string authorId)
        {
            var newComment = new Comment { PostId = postId, Content = content, AuthorId = authorId };

            this.comments.Add(newComment);

            this.comments.SaveChanges();
        }

        public IQueryable<Comment> ByPost(int postId, bool includeDeleted = false)
        {
            var commentsByPost = includeDeleted ? this.comments.AllWithDeleted() : this.comments.All();

            commentsByPost = commentsByPost.Where(c => c.PostId == postId);

            return commentsByPost;
        }
    }
}
