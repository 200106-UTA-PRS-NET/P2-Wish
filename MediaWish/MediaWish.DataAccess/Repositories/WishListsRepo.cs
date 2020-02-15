using MediaWish.Library.Entities;
using MediaWish.Library.Interfaces;
using System;
using System.Linq;
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

        public WishList CreateWishList(int gameID, int userID)
        {
            return new WishList()
            {
                users = _db.users.Where(u => u.Id == userID).Single(),
                MediaID = gameID,
                mediaTypes = _db.medias.Where(m => m.Id == GAMEMEDIA).Single()
            };
        }

        public IEnumerable<WishList> GetUserWishList(int userID)
        {
            var wishlists = _db.wishLists.Where(w => w.users.Id == userID).ToList();
            return wishlists;
        }

        public bool RemoveItemFromWishlist(int mediaID, int mediaTypeID, int userID)
        {
            try
            {
                var wishlist = _db.wishLists.Where(w => w.MediaID == mediaID && w.mediaTypes.Id == mediaTypeID && w.users.Id == userID).Single();
                _db.wishLists.Remove(wishlist);
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        public bool RemoveItemFromWishlist(int wishlistsID)
        {
            try
            {
                var wishlist = _db.wishLists.Where(w => w.Id == wishlistsID).Single();
                _db.wishLists.Remove(wishlist);
                _db.SaveChanges();
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
    }
}
