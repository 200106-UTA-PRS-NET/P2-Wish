using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
    //url: https://rawg-video-games-database.p.rapidapi.com/games?genres=action&page=2

    public class Platform2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
    }

    public class Platform
    {
        public Platform2 platform { get; set; }
    }

    public class Store2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
    }

    public class Store
    {
        public Store2 store { get; set; }
    }

    public class Rating
    {
        public int id { get; set; }
        public string title { get; set; }
        public int count { get; set; }
        public double percent { get; set; }
    }

    public class AddedByStatus
    {
        public int yet { get; set; }
        public int owned { get; set; }
        public int beaten { get; set; }
        public int toplay { get; set; }
        public int dropped { get; set; }
        public int playing { get; set; }
    }

    public class Clips
    {
        public string __invalid_name__320 { get; set; }
        public string __invalid_name__640 { get; set; }
        public string full { get; set; }
    }

    public class Clip
    {
        public string clip { get; set; }
        public Clips clips { get; set; }
        public string video { get; set; }
        public string preview { get; set; }
    }

    public class Tag
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string language { get; set; }
        public int games_count { get; set; }
        public string image_background { get; set; }
    }

    public class ShortScreenshot
    {
        public int id { get; set; }
        public string image { get; set; }
    }

    public class Platform3
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
    }

    public class ParentPlatform
    {
        public Platform3 platform { get; set; }
    }

    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
    }

    public class Result
    {
        public string slug { get; set; }
        public string name { get; set; }
        public int playtime { get; set; }
        public List<Platform> platforms { get; set; }
        public List<Store> stores { get; set; }
        public string released { get; set; }
        public bool tba { get; set; }
        public string background_image { get; set; }
        public double rating { get; set; }
        public int rating_top { get; set; }
        public List<Rating> ratings { get; set; }
        public int ratings_count { get; set; }
        public int reviews_text_count { get; set; }
        public int added { get; set; }
        public AddedByStatus added_by_status { get; set; }
        public int? metacritic { get; set; }
        public int suggestions_count { get; set; }
        public int id { get; set; }
        public object score { get; set; }
        public Clip clip { get; set; }
        public List<Tag> tags { get; set; }
        public object user_game { get; set; }
        public int reviews_count { get; set; }
        public string saturated_color { get; set; }
        public string dominant_color { get; set; }
        public List<ShortScreenshot> short_screenshots { get; set; }
        public List<ParentPlatform> parent_platforms { get; set; }
        public List<Genre> genres { get; set; }
    }


    public class RawgGamesGenreVM
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public bool user_platforms { get; set; }
        public List<Result> results { get; set; }
    }
}
