using MediaWish.Library.Interfaces;
using MediaWish.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaWish.Test.MockRepositories
{
    public class MockApiMoviesRepo: IMoviesRepo<MovieApi, MovieDetails>
    {
        static IEnumerable<Movies> movies = new List<Movies>()
        {

            new Movies()
            {
                id = 1,
                title = "dog",
                genre_ids = {1, 2},
                overview = "nice dog",
                poster_path = "google.com",
                vote_average = 2,
                release_date = "june 3"
            },

            new Movies()
            {
                id = 2,
                title = "cat",
                genre_ids = {1, 3},
                overview = "bad cat",
                poster_path = "bing.com",
                vote_average = 3,
                release_date = "june 13"
            },

        };

        public void AddMovieToWishList(int movieID, int userID)
        {
            throw new NotImplementedException();
        }

        public MovieDetails GetMovieByID(int movieID)
        {
            throw new NotImplementedException();
        }

        public MovieApi GetMoviesByGenre(int genreID, int page)
        {
            throw new NotImplementedException();
        }

        public MovieApi GetPopularMovies(int page)
        {
            throw new NotImplementedException();
        }

        public MovieApi SearchMovie(string movieStr, int page)
        {
            throw new NotImplementedException();
        }
    }
}
