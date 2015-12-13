namespace Bloggable.Services.Common.Cache
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Bloggable.Common.Constants;
    using Bloggable.Data.Contracts.Repositories;
    using Bloggable.Data.Models;
    using Bloggable.Services.Common.Cache.Contracts;

    public class CacheItemsProviderService : ICacheItemsProviderService
    {
        private readonly ICacheService cache;
        private readonly IRepository<Setting> settings;

        public CacheItemsProviderService(ICacheService cache, IRepository<Setting> settings)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            this.cache = cache;
            this.settings = settings;
        }

        public IDictionary<string, string> GetSettings(int cacheSeconds)
        {
            var forumCategories = this.cache.Get(
                CacheConstants.Settings,
                () => this.settings.All().ToDictionary(s => s.Id, s => s.Value),
                cacheSeconds);

            return forumCategories;
        }
    }
}
