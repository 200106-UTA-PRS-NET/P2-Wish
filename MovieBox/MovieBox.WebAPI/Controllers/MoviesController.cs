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
        public IEnumerable<Models.Movies> Popular()
        {
            var movies = Mapper.Map(_moviesRepo.GetPopularMovies());
            return movies;
        }

        // Get movies by genre id
        [HttpGet]
        [Route("movies/genre/{id?}")]
        public IActionResult Genre(int id)
        {
            var movies = Mapper.Map(_moviesRepo.GetMoviesByGenre(id));
            if (movies.Count() == 0 || movies == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movies);
            }
        }

        // Get movie details by movie id
        [Route("movies/details/{id=2}")] // movieID 0,1 are nonexistent so movie 2 is 
        public IActionResult Details(int id)
        {
            var movie = Mapper.Map(_moviesRepo.GetMovieByID(id));
            if (movie == null || movie.title == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movie);
            }
        }    
    }
}