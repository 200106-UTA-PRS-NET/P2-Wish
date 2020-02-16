using MediaWish.Library.Interfaces;
using MediaWish.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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
            try
            {
                var games = Mapper.Map(_gamesRepo.GetAllGames(page));
                return Ok(games.results);
            }
            catch (NullReferenceException e)
            {
                Log.Error(e, $"Error accessing page {page}");
                return NotFound();
            }

        }

        // Rawg api
        [Route("games/search/{searchGame}")]
        [HttpGet]
        public IActionResult Search(string searchGame)
        {
            try
            {
                var games = Mapper.Map(_gamesRepo.SearchGame(searchGame));
                return Ok(games);
            }
            catch (NullReferenceException e)
            {
                Log.Error(e, $"Error searching for \'{searchGame}\'");
                return NotFound();
            }
        }

        // Chicken Coop api
        [Route("games/searchC/{searchGame}")]
        [HttpGet]
        public IActionResult SearchChickenCoop(string searchGame)
        {
            try
            {
                var games = Mapper.Map(_gamesRepo.SearchGameChickenCoop(searchGame));
                return Ok(games.result);
            }
            catch (ArgumentException e)
            {
                Log.Error(e, $"Error searching for \'{searchGame}\'");
                return NotFound();
            }
        }

        [Route("games/genre={genreID}&platform={platformID}/{page?}")]
        [HttpGet]
        public IActionResult PlatformAndGenre(int platformID, int genreID, int page = 1)
        {
            try
            {
                var games = Mapper.Map(_gamesRepo.GetGamesByPlatformAndGenreId(platformID, genreID, page));
                return Ok(games.results);
            } 
            catch (NullReferenceException e)
            {
                Log.Information(e.Message);
                return NotFound();
            }
        }

        [Route("games/genre/{genreID}/{page?}")]
        [HttpGet]
        public IActionResult Genre(int genreID, int page = 1)
        {
            try
            {
                var games = Mapper.Map(_gamesRepo.GetGamesbyGenreID(genreID, page));
                return Ok(games.results);
            }
            catch (NullReferenceException e)
            {
                Log.Error(e, "no results found");
                return NotFound();
            }
        }

        [Route("games/platform/{platformID}/{page?}")]
        [HttpGet]
        public IActionResult Platform(int platformID, int page=1)
        {
            try
            {
                var games = Mapper.Map(_gamesRepo.GetGamesByPlatformId(platformID, page));
                return Ok(games.results);
            }
            catch (NullReferenceException e)
            {
                Log.Error(e, "no results found");
                return NotFound();
            }
        }

        [Route("wishlists/game/add")]
        [HttpPost]
        public IActionResult AddGameToWishList([FromBody, Bind("userID, mediaID")]WishList wishList)
        {
            try
            {
                _gamesRepo.AddGameToWishlist(wishList.MediaID, wishList.userID);
                return Ok(true);
            }
            catch (NullReferenceException)
            {
                return Ok(false);
            }


        }

        [Route("games/{gameID?}")]
        [HttpGet]
        public IActionResult Id(int gameID)
        {
            try
            {
                Games game = Mapper.Map(_gamesRepo.GetGameByID(gameID));
                return Ok(game);
            }
            catch (NullReferenceException e)
            {
                Log.Error(e, "no results found");
                return NotFound();
            }
        }
    }
}
