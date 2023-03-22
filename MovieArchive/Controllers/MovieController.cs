using Microsoft.AspNetCore.Mvc;
using MovieArchive.Interfaces;
using MovieArchive.Models;
using MovieArchive.Service;
using MovieArchive.Validations;

namespace MovieArchive.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
                _movieService = movieService;
        }
        
        [HttpGet]
        public async Task<List<Movie>> GetMovies() => await _movieService.GetAllMovies();

        [HttpGet("{name:length(50)}")]
        public async Task<ActionResult<Movie>> Get(string name)
        {
                var movie = await _movieService.GetMovieByName(name);
                return movie;
        }
        [HttpPost]
        public async Task<IActionResult> Post(MovieCreateRequest movie)
        {
               await _movieService.CreateMovie(movie);
               return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(string name, Movie updatedmovie)
        {
                var movie = await _movieService.GetMovieByName(name);
                updatedmovie.MovieName = name;
                await _movieService.UpdateMovie(name, updatedmovie);
                return Ok(movie);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string name)
        { await _movieService.DeleteMovie(name);
                return Ok();
        }
        
}