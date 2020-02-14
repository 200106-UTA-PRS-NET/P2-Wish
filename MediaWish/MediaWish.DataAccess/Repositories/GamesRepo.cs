using MediaWish.DataAccess.Models;
using MediaWish.Library.Entities;
using MediaWish.Library.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using System;

namespace MediaWish.DataAccess.Repositories
{
    public class GamesRepo : IGamesRepo<GameApi, Games, GameChickenApi>
    {
        const string GAMEMEDIA = "Video Games";

        // rapid api
        const string APIKEY = "18d888b8e8mshfd51db13a18bc87p1a2b6bjsn4b77c635255c";

        // rawg
        const string DOMAIN = "https://rawg-video-games-database.p.rapidapi.com";
        const string HOST = "rawg-video-games-database.p.rapidapi.com"; // rawg

        // chicken coop
        const string cHOST = "chicken-coop.p.rapidapi.com"; 
        const string cDOMAIN = "https://chicken-coop.p.rapidapi.com";




        readonly MediaWishContext _db;

        public GamesRepo(MediaWishContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public GameApi GetAllGames(int page)
        {
            string strRequest = $"{DOMAIN}/games?page={page}";
            var client = new RestClient(strRequest);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", HOST);
            request.AddHeader("x-rapidapi-key", APIKEY);
            IRestResponse response = client.Execute(request);

            var gameApi = JsonConvert.DeserializeObject<GameApi>(response.Content);
            return gameApi;
        }

        public Games GetGameByID(int gameID)
        {
            string strRequest = $"{DOMAIN}/games/{gameID}";
            var client = new RestClient(strRequest);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", HOST);
            request.AddHeader("x-rapidapi-key", APIKEY);
            IRestResponse response = client.Execute(request);

            var game = JsonConvert.DeserializeObject<Games>(response.Content);
            return game;
        }

        public GameApi GetGamesbyGenreID(int genreID, int page)
        {
            string strRequest = $"{DOMAIN}/games?genres={genreID}&page={page}";
            var client = new RestClient(strRequest);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", HOST);
            request.AddHeader("x-rapidapi-key", APIKEY);
            IRestResponse response = client.Execute(request);

            var gameApi = JsonConvert.DeserializeObject<GameApi>(response.Content);
            return gameApi;
        }

        public GameApi GetGamesByPlatformId(int platformID, int page)
        {
            string strRequest = $"{DOMAIN}/games?platforms={platformID}&page={page}";
            var client = new RestClient(strRequest);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", HOST);
            request.AddHeader("x-rapidapi-key", APIKEY);
            IRestResponse response = client.Execute(request);

            var gameApi = JsonConvert.DeserializeObject<GameApi>(response.Content);
            return gameApi;
        }

        public GameApi GetGamesByPlatformAndGenreId(int platformID, int genreID, int page)
        {
            string strRequest = $"{DOMAIN}/games?platforms={platformID}&genres={genreID}&page={page}";
            var client = new RestClient(strRequest);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", HOST);
            request.AddHeader("x-rapidapi-key", APIKEY);
            IRestResponse response = client.Execute(request);

            var gameApi = JsonConvert.DeserializeObject<GameApi>(response.Content);
            return gameApi;
        }

        // rawg api
        public Games SearchGame(string game)
        {
            string strRequest = $"{DOMAIN}/games/{game.Replace(' ','-')}";
            var client = new RestClient(strRequest);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", HOST);
            request.AddHeader("x-rapidapi-key", APIKEY);
            IRestResponse response = client.Execute(request);

            var games = JsonConvert.DeserializeObject<Games>(response.Content);
            return games;
        }

        // chicken coop api
        public GameChickenApi SearchGameChickenCoop(string game)
        {
            //string strRequest = $"{cDOMAIN}/games?title={game}";
            string strRequest = "https://chicken-coop.p.rapidapi.com/games?title=goat";
            var client = new RestClient(strRequest);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", cHOST);
            request.AddHeader("x-rapidapi-key", APIKEY);
            IRestResponse response = client.Execute(request);

            var gameApi = JsonConvert.DeserializeObject<GameChickenApi>(response.Content);
            return gameApi;
        }

        public void AddGameToWishlist(int gameID, int userID)
        {
            Games game = GetGameByID(gameID);

            var _users = _db.users.Where(u => u.Id == userID).Single();
            var _MediaID = gameID;
            var _mediaTypes = _db.medias.Where(m => m.MediaType == GAMEMEDIA).Single();
            var _MediaTitle = game.name;
            var _MediaPlatform = game.platforms.First().platform.name;
            var _MediaDescription = game.description_raw;

            WishList wishList = new WishList()
            {
                users = _users,
                MediaID = _MediaID,
                mediaTypes = _mediaTypes,
                MediaTitle = _MediaTitle,
                MediaPlatform = _MediaPlatform,
                MediaDescription = _MediaDescription
            };
            _db.wishLists.Add(wishList);
            _db.SaveChanges();
        }

    }
}
