using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public enum MovieGenre
    {
        Action = 28,
        Adventure = 12,
        Animation = 16,
        Comedy = 35,
        Crime = 80,
        Documentary = 99,
        Drama = 18,
        Familty = 10751,
        Fantasy = 14,
        History = 36,
        Horror = 27,
        Music = 10402,
        Mystery = 9648,
        Romance = 10749,
        SciFi = 878,
        TVMovie = 10770,
        Thriller = 53,
        War = 10752,
        Western = 37
    }

    public class SearchMovieGenreVM
    {
        public List<MovieGenre> genres { get; set; }
    }
}
