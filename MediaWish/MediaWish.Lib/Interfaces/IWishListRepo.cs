
namespace MediaWish.Library.Interfaces
{
    public interface IWishListRepo
    {
        public void AddGameToWishlist(int gameID, int userID);  // add a game to current user's wishlist
        public void AddMovieToWishList(int movieID, int userID); // add a movie to current user's wishlist
    }
}
