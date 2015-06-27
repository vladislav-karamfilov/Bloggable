namespace Bloggable.Services.Data
{
    using Bloggable.Data.Contracts.Repositories;
    using Bloggable.Data.Models;
    using Bloggable.Services.Data.Contracts;

    public class RatingsDataService : IRatingsDataService
    {
        private readonly IRepository<Rating> ratings;

        public RatingsDataService(IRepository<Rating> ratings)
        {
            this.ratings = ratings;
        }

        public void AddRating(int postId, byte value, string authorId)
        {
            var newRating = new Rating { PostId = postId, Value = value, AuthorId = authorId };

            this.ratings.Add(newRating);

            this.ratings.SaveChanges();
        }
    }
}
