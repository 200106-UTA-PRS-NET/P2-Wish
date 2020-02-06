using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using RestSharp.Serialization.Json;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {

            _logger = logger;
        }

        public IActionResult Index()
        {
            var client = new RestClient("https://chicken-coop.p.rapidapi.com/games/borderlands%202?platform=pc");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "chicken-coop.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "18d888b8e8mshfd51db13a18bc87p1a2b6bjsn4b77c635255c");
            IRestResponse response = client.Execute(request);

            ViewData["result"] = response.Content;


            return View();
        }

        public IActionResult Test()
        {


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
