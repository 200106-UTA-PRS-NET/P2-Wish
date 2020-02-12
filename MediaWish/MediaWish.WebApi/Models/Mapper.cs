using System.Collections.Generic;

namespace MediaWish.WebApi.Models
{
    public static class Mapper
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

        #region Games
        public static DataAccess.Models.Platform2 Map(Platform2 platform2)
        {
            return new DataAccess.Models.Platform2()
            {
                id = platform2.id,
                name = platform2.name
            };
        }
        public static Platform Map(DataAccess.Models.Platform platform)
        {
            return new Platform()
            {
                id = platform.platform.id,
                name = platform.platform.name
            };
        }
        public static List<Platform> Map(List<DataAccess.Models.Platform> platforms)
        {
            List<Platform> newPlatforms = new List<Platform>();
            foreach(var p in platforms)
            {
                newPlatforms.Add(Map(p));
            }
            return newPlatforms;
        }
        public static DataAccess.Models.GameGenre Map(GameGenre genre)
        {
            return new DataAccess.Models.GameGenre()
            {
                id = genre.id,
                name = genre.name
            };
        }
        public static GameGenre Map(DataAccess.Models.GameGenre genre)
        {
            return new GameGenre()
            {
                id = genre.id,
                name = genre.name
            };
        }
        public static List<DataAccess.Models.GameGenre> Map(List<GameGenre> genres)
        {
            List<DataAccess.Models.GameGenre> newGenres = new List<DataAccess.Models.GameGenre>();
            foreach(var g in genres)
            {
                newGenres.Add(Map(g));
            }
            return newGenres;
        }
        public static List<GameGenre> Map(List<DataAccess.Models.GameGenre> genres)
        {
            List<GameGenre> newGenres = new List<GameGenre>();
            foreach (var g in genres)
            {
                newGenres.Add(Map(g));
            }
            return newGenres;
        }
        public static DataAccess.Models.Games Map(Games game)
        {
            return new DataAccess.Models.Games()
            {
                id = game.id,
                name = game.name,
                released = game.released,
                genres = Map(game.genres),
                rating = game.rating,
            };
        }
        public static Games Map(DataAccess.Models.Games game)
        {
            return new Games()
            {
                id = game.id,
                name = game.name,
                released = game.released,
                genres = Map(game.genres),
                rating = game.rating,
                platforms = Map(game.platforms)
            };
        }
        public static List<DataAccess.Models.Games> Map(IEnumerable<Games> games)
        {
            List<DataAccess.Models.Games> newGames = new List<DataAccess.Models.Games>();
            foreach (var g in games)
            {
                newGames.Add(Map(g));
            }
            return newGames;
        }
        public static List<Games> Map(IEnumerable<DataAccess.Models.Games> games)
        {
            List<Games> newGames = new List<Games>();
            foreach (var g in games)
            {
                newGames.Add(Map(g));
            }
            return newGames;
        }
        public static DataAccess.Models.GameApi Map(GameApi api)
        {
            return new DataAccess.Models.GameApi()
            {
                count = api.count,
                results = Map(api.results),
                next = api.next,
                previous = api.previous
            };
        }
        public static GameApi Map(DataAccess.Models.GameApi api)
        {
            return new GameApi()
            {
                count = api.count,
                results = Map(api.results),
                next = api.next,
                previous = api.previous
            };
        }
        #endregion
    }
}
