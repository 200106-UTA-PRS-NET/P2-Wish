using MediaWish.Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaWish.Library.Interfaces
{
    public interface IGamesRepo
    {
        public IEnumerable<Medias> GetGamesbyGenreID(int genreID);  // returns list of games of specified genre given the id of the genre
        public Medias GetGameByID(int gameID); // returns the game object given the id of the game
    }
}
