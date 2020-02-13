using MediaWish.DataAccess.Models;
using MediaWish.Library.Entities;
using MediaWish.Library.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using System;

namespace MediaWish.DataAccess.Repositories
{
    public class MoviesRepo : IMoviesRepo<MovieAPI, MovieDetails>
    {
        const string API_KEY = "9e5b0ab89fd681ae90099669cd36adc8";  // api key we got for TheMovieDB api
        const string DOMAIN = "https://api.themoviedb.org";
        const string LANGUAGE = "en-US";
        const string REGION = "US";
        const string MOVIEMEDIA = "2";

        readonly MediaWishContext _db;

        public MoviesRepo(MediaWishContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void AddMovieToWishList(int movieID, int userID)
        {
            MovieDetails movie = GetMovieByID(movieID);

            WishList wishList = new WishList()
            {
                users = _db.users.Where(u => u.Id == userID).Single(),
                MediaID = movieID,
                mediaTypes = _db.medias.Where(m => m.MediaType == MOVIEMEDIA).Single(),
                MediaTitle = movie.title,
                MediaDescription = movie.overview
            };
            _db.wishLists.Add(wishList);
            _db.SaveChanges();
        }

        public MovieDetails GetMovieByID(int movieID)
        {
            string strRequest = $"{DOMAIN}/3/movie/{movieID}?api_key={API_KEY}&language={LANGUAGE}";
            var client = new RestClient(strRequest);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var movie = JsonConvert.DeserializeObject<MovieDetails>(response.Content);
            return movie;
        }

        public MovieAPI GetMoviesByGenre(int genreID, int page)
        {
            string strRequest = $"{DOMAIN}/3/discover/movie?api_key={API_KEY}&with_genres={genreID}&page={page}";
            var client = new RestClient(strRequest);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var movieAPI = JsonConvert.DeserializeObject<MovieAPI>(response.Content);
            return movieAPI;

        }

        public MovieAPI GetPopularMovies(int page)
        {
            string strRequest = $"{DOMAIN}/3/movie/popular?api_key={API_KEY}&language={LANGUAGE}&region={REGION}&page={page}";
            var client = new RestClient(strRequest);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var movieAPI = JsonConvert.DeserializeObject<MovieAPI>(response.Content);
            return movieAPI;
        }

        public MovieAPI SearchMovie(string movieStr, int page)
        {
            string strRequest = $"{DOMAIN}/3/search/movie?api_key={API_KEY}&language={LANGUAGE}&query={movieStr}&page={page}&include_adult=true&region={REGION}";
            var client = new RestClient(strRequest);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var movieAPI = JsonConvert.DeserializeObject<MovieAPI>(response.Content);
            return movieAPI;
        }
    }
}
