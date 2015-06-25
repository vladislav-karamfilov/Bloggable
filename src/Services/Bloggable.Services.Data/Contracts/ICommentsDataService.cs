namespace Bloggable.Services.Data.Contracts
{
    public interface ICommentsDataService
    {
        void AddCommentForPost(int postId, string content, string authorId);
    }
}
