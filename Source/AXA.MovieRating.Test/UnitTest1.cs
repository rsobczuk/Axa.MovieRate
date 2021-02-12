using AXA.MovieRating.DBModel;
using AXA.MovieRating.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AXA.MovieRating.Test
{
    [TestClass]
    public class CacheTest
    {
        [TestMethod]
        public void TestFormattingAsUniquity()
        {

            var input = "http://swapi.dev/api/films/1/";


            var expected = "http__swapidev_api_films_1_";
            var s = new StringFormatService();
            var exp = s.SetUrlAsUniquityFriendly(input);
            Assert.AreEqual(expected, exp);
        }

        [TestMethod]
        public void TestSumOfVotesWhenExists10And5()
        {
            var movieForTest = "Movie 1";

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("InMemDb" + Guid.NewGuid());

            var ctx = new AppDbContext(optionsBuilder.Options);
            ctx.MovieRate.Add(new MovieRate { CreationDate = DateTime.Now, MovieId = movieForTest, MovieRateId = 1, Rate = 10 });
            ctx.MovieRate.Add(new MovieRate { CreationDate = DateTime.Now, MovieId = movieForTest, MovieRateId = 2, Rate = 5 });
            ctx.SaveChanges();
            var s = new MovieService(ctx);

            var sum = s.CountVotesAsync(movieForTest).Result;

            Assert.AreEqual(15, sum);
        }

        [TestMethod]
        public void TestSumOfVotesWhenAdd5And10()
        {
            var movieForTest = "Movie 1";

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("InMemDb" + Guid.NewGuid());
            var ctx = new AppDbContext(optionsBuilder.Options);
            var s = new MovieService(ctx);

            var c = s.VoteAsync(movieForTest, 10).Result;
            var sum = s.CountVotesAsync(movieForTest).Result;
            Assert.AreEqual(10, sum);
        }

    }
}
