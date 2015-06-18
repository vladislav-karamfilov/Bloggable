namespace Bloggable.Services.Administration
{
    using System.Collections.Generic;

    using Bloggable.Data.Contracts;
    using Bloggable.Data.Models;
    using Bloggable.Services.Administration.Contracts;

    public class PostsAdministrationService : IAdministrationService<Post>
    {
        private readonly IDeletableEntityRepository<Post> posts;

        public PostsAdministrationService(IDeletableEntityRepository<Post> posts)
        {
            this.posts = posts;
        }

        public IEnumerable<Post> Read()
        {
            return this.posts.All();
        }

        public Post Get(object id)
        {
            return this.posts.GetById(id);
        }

        public void Create(Post entity)
        {
            this.posts.Add(entity);
            this.posts.SaveChanges();
        }

        public void Update(Post entity)
        {
            this.posts.Update(entity);
            this.posts.SaveChanges();
        }

        public void Delete(object id)
        {
            this.posts.Delete(id);
            this.posts.SaveChanges();
        }
    }
}
