﻿using MovieArchive.Controllers;
using MovieArchive.Models;
using MovieArchive.Interfaces;
using MovieArchive.Validations;

namespace MovieArchive.Service;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _repository;

    public MovieService(IMovieRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Movie>> GetAllMovies()
    {
        return await _repository.GetAllMovies();
    }

    public async Task<Movie> GetMovieByName(string name)
    {
        return await _repository.GetMovieByName(name)!;
    }

    public async Task CreateMovie(MovieCreateRequest movie)
    {
        Movie newMovie = new Movie
        {
            MovieName = movie.MovieName,
            ReleaseDate = movie.ReleaseYear,
            Category = movie.Category,
            Point = movie.Point,
            Note = movie.Note
        };

        await _repository.Create(newMovie);
    }



    public async Task UpdateMovie(string name,MovieUpdateRequest updatedmovie)
    {
        var movie = await _repository.GetMovieByName(name)!;
        if (updatedmovie.MovieName!=null)
        {
            movie.MovieName = updatedmovie.MovieName;
        }
        movie.Note = updatedmovie.Note;
        movie.Category = updatedmovie.Category;
        movie.Point = updatedmovie.Point;
        movie.ReleaseDate = updatedmovie.ReleaseYear;
        await _repository.UpdateMovie(movie);
    }

    public async Task DeleteMovie(string name)
    {
        await _repository.DeleteMovie(name);
    }
}