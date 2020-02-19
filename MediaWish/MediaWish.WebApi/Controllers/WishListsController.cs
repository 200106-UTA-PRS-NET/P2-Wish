using MediaWish.Library.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
using Serilog;


namespace MediaWish.WebApi.Controllers
{
    [ApiController]
    public class WishListsController : ControllerBase
    {
        private readonly IWishListRepo _wishListRepo;

        public WishListsController(IWishListRepo wishListRepo)
        {
            _wishListRepo = wishListRepo;
        }
        

        [Route("wishlists/viewall/{userID?}")]
        [HttpGet]
        public IActionResult ViewAll(int userID)
        {
            Log.Information("Starting up WishListController Loggggggggggggggg");

            var wishlists = _wishListRepo.GetUserWishList(userID);
            return Ok(wishlists);
        }

        [Route("wishlists/remove/{id}")]
        [HttpDelete]
        public IActionResult Remove(int id)
        {
            try
            {
                _wishListRepo.RemoveItemFromWishlist(id);
                return Ok(true);
            }
            catch (NullReferenceException)
            {
                return Ok(false);
            }
            catch (InvalidOperationException)
            {
                return Ok(false);
            }
        }

    }
}
