using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var client = new RestClient("https://rawg-video-games-database.p.rapidapi.com/games?genres=action&page=3");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "rawg-video-games-database.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "18d888b8e8mshfd51db13a18bc87p1a2b6bjsn4b77c635255c");
            IRestResponse response = client.Execute(request);

            RawgGamesGenreVM objec = JsonConvert.DeserializeObject<RawgGamesGenreVM>(response.Content);

            return View(objec);
        }
    }
}