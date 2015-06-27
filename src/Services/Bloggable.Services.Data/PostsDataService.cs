namespace Bloggable.Services.Data
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Bloggable.Data.Contracts.Repositories;
    using Bloggable.Data.Models;
    using Bloggable.Services.Data.Contracts;

    public class PostsDataService : IPostsDataService
    {
        private readonly IDeletableEntityRepository<Post> posts;

        public PostsDataService(IDeletableEntityRepository<Post> posts)
        {
            this.posts = posts;
        }

        public IQueryable<Post> All(Expression<Func<Post, bool>> filter = null, bool includeDeleted = false)
        {
            var allPosts = includeDeleted ? this.posts.AllWithDeleted() : this.posts.All();
            
            if (filter != null)
            {
                allPosts = allPosts.Where(filter);
            }

            return allPosts;
        }

        public IQueryable<Post> ByTag(string tag)
        {
            var postsByTag = this.posts.All().Where(p => p.Tags.Any(t => t.Name == tag));

            return postsByTag;
        }

        public IQueryable<Post> GetPage(int page, int pageSize)
        {
            if (page < 0)
            {
                throw new ArgumentOutOfRangeException("page", "page should be non-negative number.");
            }

            if (pageSize < 0)
            {
                throw new ArgumentOutOfRangeException("pageSize", "pageSize should be non-negative number.");
            }

            var postsPage = this.posts.All().OrderByDescending(p => p.CreatedOn).Skip(page * pageSize).Take(pageSize);

            return postsPage;
        }
    }
}
