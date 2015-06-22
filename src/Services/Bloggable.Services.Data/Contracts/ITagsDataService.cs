namespace Bloggable.Services.Data.Contracts
{
    using Bloggable.Data.Models;
    using Bloggable.Services.Common;

    public interface ITagsDataService : IService
    {
        Tag GetByNameOrCreate(string name);
    }
}
