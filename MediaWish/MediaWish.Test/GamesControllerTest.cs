using MediaWish.DataAccess.Models;
using MediaWish.DataAccess.Repositories;
using MediaWish.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MediaWish.Test
{
    public class GamesControllerTest
    {
        [Theory]
        [InlineData("Goat")]
        public void SearchGame_NotNull(string searchInput)
        {
            IGamesRepo<GameApi, Games, GameChickenApi> gamesRepo = new GamesRepo(new Library.Entities.MediaWishContext());

            var game = gamesRepo.SearchGame(searchInput);
            Assert.NotNull(game);
        }

    }
}
