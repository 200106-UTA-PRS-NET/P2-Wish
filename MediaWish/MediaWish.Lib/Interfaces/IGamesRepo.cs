
namespace MediaWish.Library.Interfaces
{
    public interface IGamesRepo<out T,out U>
    {
        public T GetAllGames(int page); // get all games from RawgDb
        public T GetGamesbyGenreID(int genreID, int page);  // returns list of games of specified genre given the id of the genre
        public U GetGameByID(int gameID); // returns the game object given the id of the game
        public U SearchGame(string game); // returns game given the string
        public T GetGamesByPlatformId(int platformID, int page);
        public void AddGameToWishlist(int gameID, int userID);  // add a game to current user's wishlist

    }
}
