using MediaWish.DataAccess.Models;
using MediaWish.DataAccess.Repositories;
using MediaWish.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MediaWish.Test
{
    public class MoviesRepoTest
    {
        IMoviesRepo<MovieAPI, MovieDetails> _moviesRepo = new MoviesRepo(new Library.Entities.MediaWishContext());

        [Theory]
        [InlineData("Forrest", 1)]
        public void SearchMovie_ExpectedSearchResult(string movieInput, int page)
        {
            _moviesRepo = new MoviesRepo(new Library.Entities.MediaWishContext());

            var movie = _moviesRepo.SearchMovie(movieInput, 1);
            string expectedTitle = "Forrest Gump";

            Assert.Equal(expectedTitle, movie.results[0].title);
        }


        [Theory]
        [InlineData(13, 22)]
        public void AddMovieToWishList_AddDuplicate_InvalidOperationException(int movieID, int userID)
        {
            _moviesRepo = new MoviesRepo(new Library.Entities.MediaWishContext());

            Assert.Throws<InvalidOperationException>(() => _moviesRepo.AddMovieToWishList(movieID, userID));

        }

    }
}
