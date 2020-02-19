using System.Collections.Generic;

namespace MediaWish.DataAccess.Models
{
    // class for when searching for a list of movies
    public class MovieApi
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<Movies> results { get; set; }
    }

    // class for the movie reults from lists of movies
    public class Movies
    {
        public int id { get; set; }
        public List<int> genre_ids { get; set; }
        public string title { get; set; }
        public double vote_average { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public string poster_path { get; set; }
    }

    // class for when searching for individual movies by id
    public class MovieDetails
    {
        public List<MovieGenre> genres { get; set; }
        public int id { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
        public double vote_average { get; set; }
    }

    // class for MovieDetails genre
    public class MovieGenre
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
