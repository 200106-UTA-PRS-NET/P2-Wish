using MovieBox.DataAccess.Models;
using MovieBox.Library.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBox.DataAccess.Repositories
{
    public class MoviesRepo : IMoviesRepo<Movies, MovieDetails>
    {
        const string API_KEY = "9e5b0ab89fd681ae90099669cd36adc8";
        const string DOMAIN = "https://api.themoviedb.org";
        const string LANGUAGE = "en-US";
        const string REGION = "US";


        public IEnumerable<Movies> GetPopularMovies()
        {
            string strRequest = $"{DOMAIN}/3/movie/popular?api_key={API_KEY}&language={LANGUAGE}&region={REGION}";
            var client = new RestClient(strRequest);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var movieAPI = JsonConvert.DeserializeObject<MovieAPI>(response.Content);    

            return movieAPI.results;
        }

        public List<Genre> GetGenres()
        {
            string strRequest = $"{DOMAIN}/3/movie/genre.movie/list?api_key={API_KEY}&language={LANGUAGE}";
            var client = new RestClient(strRequest);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var genres = JsonConvert.DeserializeObject<List<Genre>>(response.Content);
            return genres;

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

        public IEnumerable<Movies> GetMoviesByGenre(int genreID)
        {
            string strRequest = $"{DOMAIN}/3/discover/movie?api_key={API_KEY}&with_genres={genreID}";
            var client = new RestClient(strRequest);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var movieAPI = JsonConvert.DeserializeObject<MovieAPI>(response.Content);

            /* Adds ALL movies of a genre in one list (slow; too many requests)
             * 
            List<Movies> movies = new List<Movies>();
            for (int i = 1; i < movieAPI.total_pages; i++)
            {
                strRequest = $"{DOMAIN}/3/discover/movie?api_key={API_KEY}&with_genres={genreID}&page={i}";
                client = new RestClient(strRequest);
                request = new RestRequest(Method.GET);
                response = client.Execute(request);

                movieAPI = JsonConvert.DeserializeObject<MovieAPI>(response.Content);

                foreach(Movies m in movieAPI.results)
                {
                    movies.Add(m);
                }
            }
            */

            return movieAPI.results;
        }

    }
}
