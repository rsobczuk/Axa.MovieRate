using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AXA.MovieRating.Services.Contracts
{
    public interface IMovieService
    {
        Task<int> VoteAsync(string movieId, int rate);
        Task<int> CountVotesAsync(string movieId);
    }
}
