using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBox.DataAccess.Models
{
    public class MovieAPI
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<Movies> results { get; set; }
    }

    public class Movies
    {
        public int id { get; set; }
        public List<int> genre_ids { get; set; }
        public string title { get; set; }
        public double vote_average { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
    }
}
