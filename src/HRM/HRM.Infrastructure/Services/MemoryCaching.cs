using Microsoft.Extensions.Caching.Memory;
using System;

namespace HRM.Infrastructure.Services
{
    public class MemoryCaching : IMemoryCaching
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCaching(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }


        public void Add<T>(string key, T data)
        {
            var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(1));

            RemoveFromCache(key);

            _memoryCache.Set(key, data, cacheOptions);
        }

        public T GetFromCache<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public void RemoveFromCache(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
