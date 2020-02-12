
namespace MediaWish.Library.Interfaces
{
    public interface IMoviesRepo<out T,out U>
    {
        public T GetPopularMovies(int page);
        public T GetMoviesByGenre(int genreID, int page);
        public U GetMovieByID(int movieID);
        public T SearchMovie(string movieStr, int page);
    }
}
