namespace Bloggable.Services.Data.Contracts
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Bloggable.Data.Models;
    using Bloggable.Services.Common;

    public interface IPostsDataService : IService
    {
        IQueryable<Post> All(Expression<Func<Post, bool>> filter = null, bool includeDeleted = false);

        IQueryable<Post> ByTag(string tag);

        IQueryable<Post> GetPagePosts(int page, int pageSize, Expression<Func<Post, object>> orderKeySelector, bool ascending = true, bool includeDeleted = false);
    }
}
