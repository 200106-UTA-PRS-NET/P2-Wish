using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBox.Library.Interfaces
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

    public interface IMoviesRepo<T, U>
    {
        public IEnumerable<T> GetPopularMovies();
        public IEnumerable<T> GetMoviesByGenre(int genreID);
        public U GetMovieByID(int movieID);
    }
}
