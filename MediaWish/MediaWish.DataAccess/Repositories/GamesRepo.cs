using MediaWish.Library.Entities;
using MediaWish.Library.Interfaces;
using System;
using System.Collections.Generic;

namespace MediaWish.DataAccess.Repositories
{
    public class GamesRepo : IGamesRepo
    {
        readonly MediaWishContext _db;

        public GamesRepo(MediaWishContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public Medias GetGameByID(int gameID)
        {
            
            throw new NotImplementedException();
        }

        public IEnumerable<Medias> GetGamesbyGenreID(int genreID)
        {
            throw new NotImplementedException();
        }
    }
}
