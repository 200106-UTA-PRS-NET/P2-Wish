using MediaWish.Library.Interfaces;
using MediaWish.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [Route("wishlists/game/add")]
        [HttpPost]
        public IActionResult AddGame([FromBody, Bind("userID, mediaID") ]WishList wishList)
        {
            _wishListRepo.AddGameToWishlist(wishList.MediaID, wishList.userID);
            return Ok();
        }

        [Route("wishlists/viewall/{userID?}")]
        [HttpGet]
        public IActionResult ViewAll(int userID)
        {
            var wishlists = _wishListRepo.GetUserWishList(userID);
            return Ok(wishlists);
        }
    }
}
