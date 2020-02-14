using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWish.WebApi.Models
{
    public class GameApi
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Games> results { get; set; }
    }

    public class Games
    {
        public int id { get; set; }
        public string name { get; set; }
        public string released { get; set; }
        public double rating { get; set; }
        public List<Platform> platforms { get; set; }
        public List<GameGenre> genres { get; set; }
        public string description { get; set; }
    }

    public class Platform
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Platform2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public object image { get; set; }
        public object year_end { get; set; }
        public object year_start { get; set; }
        public int games_count { get; set; }
        public string image_background { get; set; }
    }

    public class GameGenre
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
