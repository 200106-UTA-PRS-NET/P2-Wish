using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWish.Library.Interfaces;
using MediaWish.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediaWish.WebApi.Controllers
{
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesRepo<DataAccess.Models.Movies, DataAccess.Models.MovieDetails> _moviesRepo;

        public MoviesController(IMoviesRepo<DataAccess.Models.Movies, DataAccess.Models.MovieDetails> moviesRepo)
        {
            _moviesRepo = moviesRepo;
        }

        // Get popular movies
        [HttpGet]
        [Route("movies")]
        [Route("movies/popular")]
        [Route("movies/popular/{page}")]
        public IActionResult Popular(int page=1)
        {
            try
            {
                var movies = Mapper.Map(_moviesRepo.GetPopularMovies(page));
                return Ok(movies);
            } catch (Exception)
            {
                return NotFound();
            }
        }
    }
}