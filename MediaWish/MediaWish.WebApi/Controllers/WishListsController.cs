using MediaWish.Library.Interfaces;
using MediaWish.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


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

        private readonly ILogger<WishListsController> _logger;

        public WishListsController(ILogger<WishListsController> logger)
        {
            _logger = logger;
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
