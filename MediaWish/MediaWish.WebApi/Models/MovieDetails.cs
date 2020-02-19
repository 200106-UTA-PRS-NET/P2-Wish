using System.Collections.Generic;

namespace MediaWish.WebApi.Models
{
    public class MovieDetails
    {
        public List<DataAccess.Models.MovieGenre>? genres { get; set; }
        public int id { get; set; }
        public string? overview { get; set; }
        public string? release_date { get; set; }
        public string? title { get; set; }
        public double vote_average { get; set; }
    }
}
