namespace Bloggable.Services.Common.Cache
{
    using System;
    using System.Web;
    using System.Web.Caching;

    using Bloggable.Services.Common.Cache.Contracts;

    public class HttpRuntimeCacheService : ICacheService
    {
        public T Get<T>(string cacheId, Func<T> getItemCallback, int cacheSeconds) where T : class
        {
            var item = HttpRuntime.Cache.Get(cacheId) as T;
            if (item == null)
            {
                item = getItemCallback();
                HttpContext.Current.Cache.Add(
                    cacheId,
                    item,
                    null,
                    DateTime.Now.AddSeconds(cacheSeconds),
                    TimeSpan.Zero,
                    CacheItemPriority.Default,
                    null);
            }

            return item;
        }

        public void Remove(string cacheId)
        {
            HttpRuntime.Cache.Remove(cacheId);
        }
    }
}
