using System;
using System.Collections.Generic;
using System.Text;

namespace MediaWish.Library.Interfaces
{
    public interface IMoviesRepo<T, U>
    {
        public IEnumerable<T> GetPopularMovies(int page);
        public IEnumerable<T> GetMoviesByGenre(int genreID, int page);
        public U GetMovieByID(int movieID);
    }
}
