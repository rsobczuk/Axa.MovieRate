using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AXA.MovieRating.Services.Contracts
{
    public interface IStringFormatService
    {
        string SetUrlAsUniquityFriendly(string url);
    }
}
