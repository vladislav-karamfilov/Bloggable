namespace Bloggable.Services.Data
{
    using System.Linq;

    using Bloggable.Data.Contracts;
    using Bloggable.Data.Models;
    using Bloggable.Services.Data.Contracts;

    public class PostsDataService : IPostsDataService
    {
        private readonly IDeletableEntityRepository<Post> posts;

        public PostsDataService(IDeletableEntityRepository<Post> posts)
        {
            this.posts = posts;
        }

        public IQueryable<Post> ByTag(string tag)
        {
            var postsByTag = this.posts.All().Where(p => p.Tags.Any(t => t.Name == tag));

            return postsByTag;
        }
    }
}
