namespace Bloggable.Services.Data.Contracts
{
    using Bloggable.Services.Common;

    public interface IRatingsDataService : IService
    {
        void AddRating(int postId, byte value, string authorId);
    }
}
