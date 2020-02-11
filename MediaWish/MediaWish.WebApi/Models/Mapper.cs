using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWish.WebApi.Models
{
    public class Mapper
    {
        #region Users
        public static Users Map(Library.Entities.Users users)
        {
            return new Users()
            {
                Id = users.Id,
                Name = users.Name,
                Username = users.Username,
                Email = users.Email,
                Password = users.Password,
            };
        }
        public static Library.Entities.Users Map(Users users)
        {
            return new Library.Entities.Users()
            {
                Id = users.Id,
                Name = users.Name,
                Username = users.Username,
                Email = users.Email,
                Password = users.Password,
            };
        }
        #endregion

        #region Movies
        public static Movies Map(DataAccess.Models.Movies movie)
        {
            return new Movies()
            {
                id = movie.id,
                genre_ids = movie.genre_ids,
                title = movie.title,
                vote_average = movie.vote_average,
                overview = movie.overview,
                release_date = movie.release_date
            };
        }
        public static DataAccess.Models.Movies Map(Movies movie)
        {
            return new DataAccess.Models.Movies()
            {
                id = movie.id,
                genre_ids = movie.genre_ids,
                title = movie.title,
                vote_average = movie.vote_average,
                overview = movie.overview,
                release_date = movie.release_date
            };
        }
        public static IEnumerable<Movies> Map(IEnumerable<DataAccess.Models.Movies> movies)
        {
            List<Movies> newMovies = new List<Movies>();
            foreach (var m in movies)
            {
                newMovies.Add(Map(m));
            }
            return newMovies;
        }
        public static IEnumerable<DataAccess.Models.Movies> Map(IEnumerable<Movies> movies)
        {
            List<DataAccess.Models.Movies> newMovies = new List<DataAccess.Models.Movies>();
            foreach (var m in movies)
            {
                newMovies.Add(Map(m));
            }
            return newMovies;
        }
        #endregion

        #region MovieDetails
        public static MovieDetails Map(DataAccess.Models.MovieDetails movie)
        {
            return new MovieDetails()
            {
                id = movie.id,
                genres = movie.genres,
                title = movie.title,
                vote_average = movie.vote_average,
                overview = movie.overview,
                release_date = movie.release_date
            };
        }
        public static DataAccess.Models.MovieDetails Map(MovieDetails movie)
        {
            return new DataAccess.Models.MovieDetails()
            {
                id = movie.id,
                genres = movie.genres,
                title = movie.title,
                vote_average = movie.vote_average,
                overview = movie.overview,
                release_date = movie.release_date
            };
        }
        public static IEnumerable<MovieDetails> Map(IEnumerable<DataAccess.Models.MovieDetails> movies)
        {
            List<MovieDetails> newMovies = new List<MovieDetails>();
            foreach (var m in movies)
            {
                newMovies.Add(Map(m));
            }
            return newMovies;
        }
        public static IEnumerable<DataAccess.Models.MovieDetails> Map(IEnumerable<MovieDetails> movies)
        {
            List<DataAccess.Models.MovieDetails> newMovies = new List<DataAccess.Models.MovieDetails>();
            foreach (var m in movies)
            {
                newMovies.Add(Map(m));
            }
            return newMovies;
        }
        #endregion
    }
}
