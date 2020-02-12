using MediaWish.Library.Entities;
using System.Collections.Generic;

namespace MediaWish.Library.Interfaces
{
    public interface IGamesRepo<T>
    {
        public T GetAllGames(int page); // get all games from RawgDb
        public IEnumerable<T> GetGamesbyGenreID(int genreID);  // returns list of games of specified genre given the id of the genre
        public T GetGameByID(int gameID); // returns the game object given the id of the game
    }
}
