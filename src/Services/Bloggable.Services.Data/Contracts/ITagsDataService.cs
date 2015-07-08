namespace Bloggable.Services.Data.Contracts
{
    using System.Linq;

    using Bloggable.Data.Models;
    using Bloggable.Services.Common;

    public interface ITagsDataService : IService
    {
        Tag GetById(object id);

        Tag GetByNameOrCreate(string name);

        IQueryable<Tag> GetMostPopularTags(int count);
    }
}
