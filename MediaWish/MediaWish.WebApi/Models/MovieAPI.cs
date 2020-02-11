using System.Collections.Generic;

namespace MediaWish.WebApi.Models
{
    public class MovieAPI
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<Movies> results { get; set; }
    }


}
