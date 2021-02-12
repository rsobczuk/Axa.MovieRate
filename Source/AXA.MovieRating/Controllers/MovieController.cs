using AXA.MovieRating.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AXA.MovieRating.Controllers
{
    public class MovieController : Controller
    {
        IMovieSourceService _movieSourceService;
        IMovieService _movieService;

        public MovieController(IMovieSourceService movieSourceService, IMovieService movieService)
        {
            _movieSourceService = movieSourceService;
            _movieService = movieService;
        }
        public async Task<IActionResult> Index()
        {

            var moviesList = await _movieSourceService.GetAllAsync();
            return View(moviesList);
        }

        public async Task<IActionResult> Vote(string movieId, int rate)
        {
            int votes = 0;
            try
            {
                await _movieService.VoteAsync(movieId, rate);
                votes = await _movieService.CountVotesAsync(movieId);
            }
            catch (Exception)
            {
                return Ok("ERROR");
            }

            return Ok(votes);

        }
    }
}