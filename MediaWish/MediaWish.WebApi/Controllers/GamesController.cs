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
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepo<DataAccess.Models.GameApi> _gamesRepo;

        public GamesController(IGamesRepo<DataAccess.Models.GameApi> gamesRepo)
        {
            _gamesRepo = gamesRepo;
        }

        [Route("games")]
        [Route("games/all/{page?}")]
        [HttpGet]
        public IActionResult All(int page=1)
        {
            var games = Mapper.Map(_gamesRepo.GetAllGames(page));
            return Ok(games);
        }
    }
}
