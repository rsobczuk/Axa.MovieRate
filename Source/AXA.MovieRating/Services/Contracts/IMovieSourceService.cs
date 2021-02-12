using AXA.MovieRating.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AXA.MovieRating.Services.Contracts
{
    public interface IMovieSourceService
    {
        Task<IEnumerable<Movie>> GetAllAsync();        
    }
}
