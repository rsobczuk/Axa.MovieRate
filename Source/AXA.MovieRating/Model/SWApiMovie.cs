using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AXA.MovieRating.Model
{
    public class SWApiMovieResponse
    {
        public int count { get; set; }
        public IList<SWApiMovie> results;
    }

    public class SWApiMovie
    {
        public string title { get; set; }
        public int episode_id { get; set; }
        public string opening_crawl { get; set; }
        public string director { get; set; }
        public string producer { get; set; }
        public string url { get; set; }

    }
}
