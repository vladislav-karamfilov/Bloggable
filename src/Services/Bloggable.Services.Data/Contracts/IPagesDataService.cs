namespace Bloggable.Services.Data.Contracts
{
    using Bloggable.Data.Models;
    using Bloggable.Services.Common;

    public interface IPagesDataService : IService
    {
        Page GetByPermalink(string permalink, bool includeDeleted = false);
    }
}
