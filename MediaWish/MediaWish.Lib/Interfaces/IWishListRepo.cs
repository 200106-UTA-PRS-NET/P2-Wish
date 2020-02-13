
using MediaWish.Library.Entities;
using System.Collections.Generic;

namespace MediaWish.Library.Interfaces
{
    public interface IWishListRepo
    {
        public void AddGameToWishlist(int gameID, int userID);  // add a game to current user's wishlist
        public void AddMovieToWishList(int movieID, int userID); // add a movie to current user's wishlist
        public IEnumerable<WishList> GetUserWishList(int userID); //

        public WishList CreateWishList(int gameID, int userID); // for testing purposes
    }
}
