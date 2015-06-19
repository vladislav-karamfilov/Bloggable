namespace Bloggable.Services.Common.Cache.Contracts
{
    using System;

    using Bloggable.Services.Common;

    public interface ICacheService : IService
    {
        T Get<T>(string cacheId, Func<T> getItemCallback, int cacheSeconds) where T : class;

        void Remove(string cacheId);
    }
}
