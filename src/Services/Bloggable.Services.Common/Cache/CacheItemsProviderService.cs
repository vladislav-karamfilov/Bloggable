namespace Bloggable.Services.Common.Cache
{
    using Bloggable.Services.Common.Cache.Contracts;

    public class CacheItemsProviderService : ICacheItemsProviderService
    {
        private readonly ICacheService cache;

        public CacheItemsProviderService(ICacheService cache)
        {
            this.cache = cache;
        }
    }
}
