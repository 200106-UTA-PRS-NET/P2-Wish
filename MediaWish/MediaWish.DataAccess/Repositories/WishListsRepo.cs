using MediaWish.Library.Entities;
using MediaWish.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaWish.DataAccess.Repositories
{
    public class WishListsRepo : IWishListRepo
    {

        const int GAMEMEDIA = 1;
        const int MOVIEMEDIA = 2;

        readonly MediaWishContext _db;

        public WishListsRepo(MediaWishContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void AddGameToWishlist(int gameID, int userID)
        {

        }

        public void AddMovieToWishList(int movieID, int userID)
        {
            throw new NotImplementedException();
        }
    }
}
