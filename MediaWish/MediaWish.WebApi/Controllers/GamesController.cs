using MediaWish.Library.Interfaces;
using MediaWish.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;

namespace MediaWish.WebApi.Controllers
{
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepo<DataAccess.Models.GameApi, DataAccess.Models.Games> _gamesRepo;

        public GamesController(IGamesRepo<DataAccess.Models.GameApi, DataAccess.Models.Games> gamesRepo)
        {
            _gamesRepo = gamesRepo;
        }
        private readonly ILogger<GamesController> _logger;

        public GamesController(ILogger<GamesController> logger)
        {
            _logger = logger;
        }

        [Route("games")]
        [Route("games/all/{page?}")]
        [HttpGet]
        public IActionResult All(int page=1)
        {
            var games = Mapper.Map(_gamesRepo.GetAllGames(page));
            if (games.count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(games);
            }
        }

        [Route("games/genre/{genreID}/{page?}")]
        [HttpGet]
        public IActionResult Genre(int genreID, int page=1)
        {
            var games = Mapper.Map(_gamesRepo.GetGamesbyGenreID(genreID, page));
            if (games.count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(games);
            }
        }

        [Route("games/search/{searchGame}")]
        [HttpGet]
        public IActionResult Search(string searchGame)
        {
            try
            {
                var games = Mapper.Map(_gamesRepo.SearchGame(searchGame));
                return Ok(games);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("games/platform/{platformID}/{page?}")]
        [HttpGet]
        public IActionResult Platform(int platformID, int page=1)
        {
            var games = Mapper.Map(_gamesRepo.GetGamesByPlatformId(platformID, page));
            if (games.count == 0)
            {
                return NotFound();
            } 
            else
            {
                return Ok(games);
            }         
        }

        [Route("wishlists/game/add")]
        [HttpPost]
        public IActionResult AddGameToWishList([FromBody, Bind("userID, mediaID")]WishList wishList)
        {
            _gamesRepo.AddGameToWishlist(wishList.MediaID, wishList.userID);
            return Ok();
        }

        [Route("games/{gameID?}")]
        [HttpGet]
        public IActionResult Id(int gameID)
        {
            Games game = Mapper.Map(_gamesRepo.GetGameByID(gameID));
            return Ok(game);
        }


    }
}
