using System.Collections.Generic;

namespace MediaWish.DataAccess.Models
{
    public class GameApi
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Games> results { get; set; }
    }

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

    public class Games
    {
        public int id { get; set; }
        public string name { get; set; }
        public string released { get; set; }
        public double rating { get; set; }
        public List<Platform> platforms { get; set; }
        public List<GameGenre> genres { get; set; }
        public string description_raw { get; set; }
    }
    public class Platform
    {
        public Platform2 platform { get; set; }
        public string released_at { get; set; }
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
        public string slug { get; set; }
        public int games_count { get; set; }
    }
}
