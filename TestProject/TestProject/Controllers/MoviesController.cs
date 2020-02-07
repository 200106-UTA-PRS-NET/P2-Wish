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

        public IActionResult MoviesByGenreID(int? id)
        {

            return View();
        }
    }
}