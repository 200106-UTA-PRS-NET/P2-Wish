using MediaWish.DataAccess.Models;
using MediaWish.DataAccess.Repositories;
using MediaWish.Library.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MediaWish.Test
{
    public class GamesRepoTest
    {

        IGamesRepo<GameApi, Games, GameChickenApi> gamesRepo = new GamesRepo(new Library.Entities.MediaWishContext());

        [Theory]
        [InlineData("Goat")]
        public void SearchGame_NotNull(string searchInput)
        {
            gamesRepo = new GamesRepo(new Library.Entities.MediaWishContext());

            var game = gamesRepo.SearchGame(searchInput);
            Assert.NotNull(game);
        }

        [Theory]
        [InlineData("Goat")]
        public void SearchGameC_NotNull(string searchInput)
        {
            gamesRepo = new GamesRepo(new Library.Entities.MediaWishContext());

            var games = gamesRepo.SearchGameChickenCoop(searchInput);
            Assert.NotNull(games);
        }

        [Theory]
        [InlineData(4,10,1)]
        public void GetGamesByPlatformAndGenreId_NotNull(int platformID, int genreID, int page)
        {
            gamesRepo = new GamesRepo(new Library.Entities.MediaWishContext());

            var games = gamesRepo.GetGamesByPlatformAndGenreId(platformID, genreID, page);

            Assert.NotNull(games);
        }

        [Theory]
        [InlineData(4, 1)]
        public void GetGamesByPlatformId_NotNull(int platformID, int page)
        {
            gamesRepo = new GamesRepo(new Library.Entities.MediaWishContext());

            var games = gamesRepo.GetGamesByPlatformId(platformID, page);

            Assert.NotNull(games);
        }

        [Theory]
        [InlineData(10, 1)]
        public void GetGamesbyGenreID_NotNull(int genreID, int page)
        {
            gamesRepo = new GamesRepo(new Library.Entities.MediaWishContext());

            var games = gamesRepo.GetGamesbyGenreID(genreID, page);

            Assert.NotNull(games);
        }


        [Theory]
        [InlineData(10)]
        public void GetGameByID_NotNull(int gameID)
        {
            gamesRepo = new GamesRepo(new Library.Entities.MediaWishContext());

            var games = gamesRepo.GetGameByID(gameID);

            Assert.NotNull(games);
        }

        [Theory]
        [InlineData(1)]
        public void GetAllGames_NotNull(int page)
        {
            gamesRepo = new GamesRepo(new Library.Entities.MediaWishContext());

            var games = gamesRepo.GetAllGames(page);

            Assert.NotNull(games);
        }
    }
}
