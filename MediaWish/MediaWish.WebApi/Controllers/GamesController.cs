using MediaWish.Library.Interfaces;
using MediaWish.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

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

        [Route("games")]
        [Route("games/all/{page?}")]
        [HttpGet]
        public IActionResult All(int page=1)
        {
            var games = Mapper.Map(_gamesRepo.GetAllGames(page));
            if (games.count == 0 || games == null)
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
            if (games.count == 0 || games.Equals(null))
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
            var games = Mapper.Map(_gamesRepo.SearchGame(searchGame));
            if (games.Equals(null))
            {
                return NotFound();
            }
            else
            {
                return Ok(games);
            }
        }

        [Route("games/platform/{platformID}/{page?}")]
        [HttpGet]
        public IActionResult Platform(int platformID, int page=1)
        {
            var games = Mapper.Map(_gamesRepo.GetGamesByPlatformId(platformID, page));
            if (games.count == 0 || games.Equals(null))
            {
                return NotFound();
            } 
            else
            {
                return Ok(games);
            }         
        }
    }
}
