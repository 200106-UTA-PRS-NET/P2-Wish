using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using TestProject.Models;

namespace TestProject.Controllers
{

    public class MoviesController : Controller
    {
        public IActionResult Search()
        {

            SearchMovieGenreVM movieGenres = new SearchMovieGenreVM()
            {
                genres = Enum.GetValues(typeof(MovieGenre)).OfType<MovieGenre>().ToList()
            };

            return View(movieGenres);
        }

        public IActionResult MoviesByGenreID(IFormCollection formCollection)
        {
            string selGenreID = formCollection["selectedGenreID"];

            string reqString = "https://api.themoviedb.org/3/discover/movie?api_key=9e5b0ab89fd681ae90099669cd36adc8&with_genres=" + selGenreID;
            var client = new RestClient(reqString);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "rawg-video-games-database.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "18d888b8e8mshfd51db13a18bc87p1a2b6bjsn4b77c635255c");
            IRestResponse response = client.Execute(request);

            var movies = JsonConvert.DeserializeObject<MoviesVM>(response.Content);

            return View(movies.results);
        }
    }
}