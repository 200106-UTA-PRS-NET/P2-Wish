using System.Collections.Generic;

namespace MediaWish.Library.Interfaces
{
    public interface IMoviesRepo<T, U>
    {
        public T GetPopularMovies(int page);
        public T GetMoviesByGenre(int genreID, int page);
        public U GetMovieByID(int movieID);

        public T SearchMovie(string movieStrint, int page);
    }
}
