using MediaWish.Library.Interfaces;
using MediaWish.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
using Serilog;

namespace MediaWish.WebApi.Controllers
{
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepo<DataAccess.Models.GameApi, DataAccess.Models.Games, DataAccess.Models.GameChickenApi> _gamesRepo;

        public GamesController(IGamesRepo<DataAccess.Models.GameApi, DataAccess.Models.Games, DataAccess.Models.GameChickenApi> gamesRepo)
        {
            _gamesRepo = gamesRepo;
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
                Log.Information("Starting up GamesController Loggggggg");

                return Ok(games);

            }

        }

        // Rawg api
        [Route("games/search/{searchGame}")]
        [HttpGet]
        public IActionResult Search(string searchGame)
        {
            try
            {
                Log.Information("Starting up GamesController Loggggggg");

                var games = Mapper.Map(_gamesRepo.SearchGame(searchGame));
                return Ok(games);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Chicken Coop api
        [Route("games/searchC/{searchGame}")]
        [HttpGet]
        public IActionResult SearchChickenCoop(string searchGame)
        {

                var games = Mapper.Map(_gamesRepo.SearchGameChickenCoop(searchGame));
                return Ok(games);

        }

        [Route("games/genre={genreID}&platform={platformID}/{page?}")]
        [HttpGet]
        public IActionResult PlatformAndGenre(int platformID, int genreID, int page = 1)
        {
            var games = Mapper.Map(_gamesRepo.GetGamesByPlatformAndGenreId(platformID, genreID, page));
            if (games.count == 0)
            {
                return NotFound();
            }
            else
            {
                Log.Information("Starting up GamesController Loggggggggg");

                return Ok(games);
            }
        }

        [Route("games/genre/{genreID}/{page?}")]
        [HttpGet]
        public IActionResult Genre(int genreID, int page = 1)
        {
            var games = Mapper.Map(_gamesRepo.GetGamesbyGenreID(genreID, page));
            if (games.count == 0)
            {
                return NotFound();
            }
            else
            {
                Log.Information("Starting up GamesController Logggggggggggggg");

                return Ok(games);
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
                Log.Information("Starting up GamesController Logggggggggggggg");

                return Ok(games);
            }         
        }

        [Route("wishlists/game/add")]
        [HttpPost]
        public IActionResult AddGameToWishList([FromBody, Bind("userID, mediaID")]WishList wishList)
        {
            Log.Information("Starting up GamesController Log");

            _gamesRepo.AddGameToWishlist(wishList.MediaID, wishList.userID);
            return Ok();
        }

        [Route("games/{gameID?}")]
        [HttpGet]
        public IActionResult Id(int gameID)
        {
            Log.Information("Starting up GamesController Loggggggggggg");

            Games game = Mapper.Map(_gamesRepo.GetGameByID(gameID));
            return Ok(game);
        }


    }
}
