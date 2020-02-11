using MediaWish.DataAccess.Models;
using MediaWish.Library.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace MediaWish.DataAccess.Repositories
{
    public class MoviesRepo : IMoviesRepo<Movies, MovieDetails>
    {
        const string API_KEY = "9e5b0ab89fd681ae90099669cd36adc8";  // api key we got for TheMovieDB api
        const string DOMAIN = "https://api.themoviedb.org";
        const string LANGUAGE = "en-US";
        const string REGION = "US";

        public MovieDetails GetMovieByID(int movieID)
        {
            string strRequest = $"{DOMAIN}/3/movie/{movieID}?api_key={API_KEY}&language={LANGUAGE}";
            var client = new RestClient(strRequest);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var movie = JsonConvert.DeserializeObject<MovieDetails>(response.Content);
            return movie;
        }

        public IEnumerable<Movies> GetMoviesByGenre(int genreID, int page=1)
        {
            string strRequest = $"{DOMAIN}/3/discover/movie?api_key={API_KEY}&with_genres={genreID}&page={page}";
            var client = new RestClient(strRequest);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var movieAPI = JsonConvert.DeserializeObject<MovieAPI>(response.Content);
            return movieAPI.results;

        }

        public IEnumerable<Movies> GetPopularMovies(int page=1)
        {
            string strRequest = $"{DOMAIN}/3/movie/popular?api_key={API_KEY}&language={LANGUAGE}&region={REGION}&page={page}";
            var client = new RestClient(strRequest);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var movieAPI = JsonConvert.DeserializeObject<MovieAPI>(response.Content);
            return movieAPI.results;
        }
    }
}
