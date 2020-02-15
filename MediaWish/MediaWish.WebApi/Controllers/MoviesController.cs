using System;
using System.Linq;
using MediaWish.Library.Interfaces;
using MediaWish.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace MediaWish.WebApi.Controllers
{
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesRepo<DataAccess.Models.MovieAPI, DataAccess.Models.MovieDetails> _moviesRepo;
        private readonly ILogger<MoviesController> _logger;


        public MoviesController(IMoviesRepo<DataAccess.Models.MovieAPI, DataAccess.Models.MovieDetails> moviesRepo)//, Logger<MoviesController> logger
        {
            _moviesRepo = moviesRepo;
           // _logger = logger;

        }


        // Get popular movies
        [Route("movies")]
        [Route("movies/popular")]
        [Route("movies/popular/{page}")]
        [HttpGet] //added these HttpGet 's to see documentation for swagger, needed to be on top of IaAction result
        public IActionResult Popular(int page=1)
        {
            try
            {
                Log.Information("Starting up MoviesController Logggggggggg");

                var movies = _moviesRepo.GetPopularMovies(page);
                return Ok(movies.results);
            } catch (Exception)
            {
                return NotFound();
            }
        }

        // Get movie details by movie id
        [Route("movies/details/{id}")] // movieID 0,1 are nonexistent so movie 2 is 
        [HttpGet]
        public IActionResult Details(int id=2)
        {
            var movie = Mapper.Map(_moviesRepo.GetMovieByID(id));
            if (movie == null || movie.title == null)
            {

                return NotFound();
            }
            else
            {
                Log.Information("Starting up MoviesController Logggggggggg");

                return Ok(movie);
            }
        }

        // Get movies by genre id
        [Route("movies/genre/{id?}/{page?}")]
        [HttpGet]
        public IActionResult Genre(int id, int page=1)
        {
            var movies = _moviesRepo.GetMoviesByGenre(id, page);
            if (movies.results.Count() == 0 || movies == null)
            {
                return NotFound();
            }
            else
            {
                Log.Information("Starting up MoviesController Logggggggggg");

                return Ok(movies.results);
            }
        }

        //[HttpGet]
        [Route("movies/search/{movieSearch}/{page?}")]
        [HttpGet]
        public IActionResult Search(string movieSearch, int page=1)
        {
            var movies = _moviesRepo.SearchMovie(movieSearch, page);
            if (movies.results.Count() == 0 || movies == null)
            {
                return NotFound();
            }
            else
            {
                Log.Information("Starting up MoviesController Logggggggggg");

                return Ok(movies.results);
            }
        }

        [Route("wishlists/movie/add")]
        [HttpPost]
        public IActionResult AddMovieToWishList([FromBody, Bind("userID, mediaID")]WishList wishList)
        {
            _moviesRepo.AddMovieToWishList(wishList.MediaID, wishList.userID);
            return Ok();
        }
    }
}