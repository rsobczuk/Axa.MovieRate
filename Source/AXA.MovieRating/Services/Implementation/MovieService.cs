using AXA.MovieRating.DBModel;
using AXA.MovieRating.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AXA.MovieRating.Services.Implementation
{
   
    public class MovieService : IMovieService
    {
        AppDbContext _ctx;

        public MovieService(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<int> VoteAsync(string movieId, int rate)
        {
            var newRate = new MovieRate();
            newRate.CreationDate = DateTime.Now;
            newRate.MovieId = movieId;
            newRate.Rate = rate;

            _ctx.Add(newRate);

            var id = await _ctx.SaveChangesAsync();
            return id;
        }

        public async Task<int> CountVotesAsync(string movieId)
        {
            var data = await _ctx.MovieRate.Where(m => m.MovieId == movieId).SumAsync(c => c.Rate);
            return data;
        }        
    }
}