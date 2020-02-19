using System.Collections.Generic;

namespace MediaWish.WebApi.Models
{

    public class GameChickenApi
    {
        public List<GamesChicken> result { get; set; }
        public int countResult { get; set; }
    }


    public class GamesChicken
    {
        public string title { get; set; }
        public string platform { get; set; }
    }

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
        public string background_image { get; set; }
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
        public int games_count { get; set; }
    }

    public class GameGenre
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
