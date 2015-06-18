namespace Bloggable.Services.Data.Contracts
{
    using System.Linq;

    using Bloggable.Data.Models;
    using Bloggable.Services.Common;

    public interface IPostsDataService : IService
    {
        IQueryable<Post> ByTag(string tag);
    }
}
