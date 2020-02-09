using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieBox.DataAccess.Models;
using MovieBox.Library.Interfaces;
using MovieBox.WebAPI.Models;

namespace MovieBox.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMoviesRepo<DataAccess.Models.Movies> _moviesRepo;

        public MoviesController(IMoviesRepo<DataAccess.Models.Movies> moviesRepo)
        {
            _moviesRepo = moviesRepo;
        }

        [HttpGet]
        public IEnumerable<Models.Movies> Get()
        {
            var movies = Mapper.Map(_moviesRepo.GetPopularMovies());
            return movies;
        }
    }
}