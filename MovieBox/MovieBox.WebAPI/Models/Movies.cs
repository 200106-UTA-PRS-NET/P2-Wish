using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBox.WebAPI.Models
{
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
