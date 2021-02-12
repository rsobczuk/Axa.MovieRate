using AXA.MovieRating.Services.Contracts;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AXA.MovieRating.Services.Implementation
{

    public class MemoryCacheService : ICacheService
    {
        private IMemoryCache _cache;        

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public object getFromCache(string entryName)
        {
            object entryValue = null;

            _cache.TryGetValue(entryName, out entryValue);

            return entryValue;
        }

        public void saveInCache(object obj, string entryName, TimeSpan timespan)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()              
                .SetSlidingExpiration(timespan);

            _cache.Set(entryName, obj, cacheEntryOptions);
        }
    }
}