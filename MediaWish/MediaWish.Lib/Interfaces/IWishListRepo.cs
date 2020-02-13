
using MediaWish.Library.Entities;
using System.Collections.Generic;

namespace MediaWish.Library.Interfaces
{
    public interface IWishListRepo
    {
        public IEnumerable<WishList> GetUserWishList(int userID); // get list of wishlist given userID
        public bool RemoveItemFromWishlist(int mediaID, int mediaTypeID, int userID); // removes item from user's wishlist
        public WishList CreateWishList(int gameID, int userID); // for testing purposes
    }
}
