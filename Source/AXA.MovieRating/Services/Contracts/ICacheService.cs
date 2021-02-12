using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AXA.MovieRating.Services.Contracts
{
    public interface ICacheService
    {
        void saveInCache(object obj, string entryName, TimeSpan timespan);
        object getFromCache(string entryName);
    }
}
