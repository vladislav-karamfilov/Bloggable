namespace Bloggable.Services.Common.Cache.Contracts
{
    using System.Collections.Generic;

    using Bloggable.Common.Constants;

    public interface ICacheItemsProviderService : IService
    {
        IDictionary<string, string> GetSettings(int cacheSeconds = CacheConstants.DefaultCacheSeconds);
    }
}
