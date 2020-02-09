using MovieBox.DataAccess.Models;
using MovieBox.Library.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBox.DataAccess.Repositories
{
    public class MoviesRepo : IMoviesRepo<Movies>
    {
        const string API_KEY = "9e5b0ab89fd681ae90099669cd36adc8";
        const string DOMAIN = "https://api.themoviedb.org/3/movie/";
        const string LANGUAGE = "en-US";
        const string REGION = "US";


        public IEnumerable<Movies> GetPopularMovies()
        {
            string strRequest = $"{DOMAIN}popular?api_key={API_KEY}&language={LANGUAGE}&region={REGION}";
            var client = new RestClient(strRequest);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var movieAPI = JsonConvert.DeserializeObject<MovieAPI>(response.Content);    

            return movieAPI.results;
        }

        public List<MovieGenre> GetGenres()
        {
            throw new NotImplementedException();
        }

        public Movies GetMovieByID(int movieID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movies> GetMoviesByGenre(int genreID)
        {
            throw new NotImplementedException();

        }

    }
}
