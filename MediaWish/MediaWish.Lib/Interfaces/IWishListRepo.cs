
namespace MediaWish.Library.Interfaces
{
    public interface IWishListRepo
    {
        public void AddGameToWishlist(int gameID);  // add a game to current user's wishlist
        public void AddMovieToWishList(int movieID); // add a movie to current user's wishlist
    }
}
