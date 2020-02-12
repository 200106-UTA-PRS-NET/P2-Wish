﻿using MediaWish.Library.Entities;
using System.Collections.Generic;

namespace MediaWish.Library.Interfaces
{
    public interface IGamesRepo<T, U>
    {
        public T GetAllGames(int page); // get all games from RawgDb
        public T GetGamesbyGenreID(int genreID, int page);  // returns list of games of specified genre given the id of the genre
        public T GetGameByID(int gameID); // returns the game object given the id of the game
        public U SearchGame(string game); // returns game given the string
        public T GetGamesByPlatformId(int platformID, int page);
    }
}
