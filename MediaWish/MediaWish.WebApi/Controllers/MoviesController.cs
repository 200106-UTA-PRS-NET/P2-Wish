using System;
using System.Linq;
using MediaWish.Library.Interfaces;
using MediaWish.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Web.Http.Cors;

namespace MediaWish.WebApi.Controllers
{
    [ApiController]

    public class MoviesController : ControllerBase
    {
        private readonly IMoviesRepo<DataAccess.Models.MovieAPI, DataAccess.Models.MovieDetails> _moviesRepo;

        public MoviesController(IMoviesRepo<DataAccess.Models.MovieAPI, DataAccess.Models.MovieDetails> moviesRepo)
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
                var movies = _moviesRepo.GetPopularMovies(page);
                return Ok(movies);
            } catch (Exception)
            {
                return NotFound();
            }
        }

        // Get movie details by movie id
        [Route("movies/details/{id}")] // movieID 0,1 are nonexistent so movie 2 is 
        public IActionResult Details(int id=2)
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

        // Get movies by genre id
        [HttpGet]
        [Route("movies/genre/{id?}/{page?}")]
        public IActionResult Genre(int id, int page=1)
        {
            var movies = _moviesRepo.GetMoviesByGenre(id, page);
            if (movies.results.Count() == 0 || movies == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movies);
            }
        }
    }
}