using AXA.MovieRating.Model;
using AXA.MovieRating.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AXA.MovieRating.Services.Implementation
{
    public class SWApiMovieService : IMovieSourceService
    {
        ICacheService _cacheService;
        IMovieService _movieService;
        IStringFormatService _stringFormatService;
        IConfiguration _configuration;

        public SWApiMovieService(ICacheService cacheService, 
                                    IMovieService movieService,
                                    IStringFormatService stringFormatService,
                                    IConfiguration configuration)
        {
            _cacheService = cacheService;
            _movieService = movieService;
            _stringFormatService = stringFormatService;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            List<Movie> movies;
            SWApiMovieResponse swApiMovies;

            var url = _configuration["MovieApiUrl"];

            movies = _cacheService.getFromCache("Movies") as List<Movie>;

            if (movies == null)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(url))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        swApiMovies = JsonConvert.DeserializeObject<SWApiMovieResponse>(apiResponse);
                    }
                }

                if (swApiMovies != null)
                {
                    movies = new List<Movie>();
                    foreach (var m in swApiMovies.results)
                    {
                        movies.Add(
                            new Movie()
                            {
                                Title = m.title,
                                Director = m.director,
                                EpisodeId = m.episode_id,
                                OpeningCrawl = m.opening_crawl,
                                Producer = m.producer,
                                Url = m.url,
                                Uniquity = _stringFormatService.SetUrlAsUniquityFriendly(m.url)
                            });
                    }

                    _cacheService.saveInCache(movies, "Movies", TimeSpan.FromSeconds(120));
                }
            }

            foreach(var m in movies)
            {
                m.Rate = await _movieService.CountVotesAsync(m.Url);
            }

            return movies;
        }

        
    }
}