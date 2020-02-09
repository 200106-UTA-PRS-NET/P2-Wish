using MovieBox.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBox.WebAPI.Models
{
    public class Mapper
    {
        #region Users
        public static Users Map(Library.Users user)
        {
            return new Users()
            {
                Id = user.Id,
                Name = user.Name
            };
        }
        public static Library.Users Map(Users user)
        {
            return new Library.Users()
            {
                Id = user.Id,
                Name = user.Name
            };
        }
        public static IEnumerable<Users> Map(IEnumerable<Library.Users> users)
        {
            List<Users> newUsers = new List<Users>();
            foreach (var user in users)
            {
                newUsers.Add(Map(user));
            }
            return newUsers;
        }
        public static IEnumerable<Library.Users> Map(IEnumerable<Users> users)
        {
            List<Library.Users> newUsers = new List<Library.Users>();
            foreach (var user in users)
            {
                newUsers.Add(Map(user));
            }
            return newUsers;
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
            foreach(var m in movies)
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
    }
}
