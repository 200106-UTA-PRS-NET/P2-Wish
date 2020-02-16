using MediaWish.Library.Interfaces;
using MediaWish.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Serilog;


namespace MediaWish.WebApi.Controllers
{
    [ApiController]
    public class WishListsController : ControllerBase
    {
        private readonly IWishListRepo _wishListRepo;
        private readonly ILogger<WishListsController> _logger;
        public WishListsController(IWishListRepo wishListRepo)//, Logger<WishListsController> logger
        {
            _wishListRepo = wishListRepo;
           // _logger = logger;



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
                var isRemoved = _wishListRepo.RemoveItemFromWishlist(id);
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
