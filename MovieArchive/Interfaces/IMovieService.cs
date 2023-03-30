using MovieArchive.Controllers;
using MovieArchive.Models;
using MovieArchive.Validations;

namespace MovieArchive.Interfaces;

public interface IMovieService
{
    Task<List<Movie>> GetAllMovies();
    Task<Movie> GetMovieByName(string name);
    Task CreateMovie(MovieCreateRequest movie);
    Task UpdateMovie( string name,MovieUpdateRequest movie);
    Task DeleteMovie(string name);
    
}