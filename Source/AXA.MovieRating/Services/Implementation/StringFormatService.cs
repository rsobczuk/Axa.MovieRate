using AXA.MovieRating.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AXA.MovieRating.Services.Implementation
{
    public class StringFormatService : IStringFormatService
    {
        public string SetUrlAsUniquityFriendly(string url)
        {
            return url.Replace("/", "_").Replace(".", "").Replace(":", "");
        }
    }
}