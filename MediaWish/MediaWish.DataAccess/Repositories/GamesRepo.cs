using MediaWish.DataAccess.Models;
using MediaWish.Library.Entities;
using MediaWish.Library.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using System;

namespace MediaWish.DataAccess.Repositories
{
    public class GamesRepo : IGamesRepo<GameApi, Games>
    {
        const string DOMAIN = "https://rawg-video-games-database.p.rapidapi.com";
        const string APIKEY = "18d888b8e8mshfd51db13a18bc87p1a2b6bjsn4b77c635255c";
        const string HOST = "rawg-video-games-database.p.rapidapi.com";
        const string GAMEMEDIA = "1";


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

        public void AddGameToWishlist(int gameID, int userID)
        {
            Games game = GetGameByID(gameID);

            WishList wishList = new WishList()
            {
                users = _db.users.Where(u => u.Id == userID).Single(),
                MediaID = gameID,
                mediaTypes = _db.medias.Where(m => m.MediaType == GAMEMEDIA).Single(),
                MediaTitle = game.name,
                MediaPlatform = game.platforms.First().platform.name,
            };
            _db.wishLists.Add(wishList);
            _db.SaveChanges();
        }
    }
}
