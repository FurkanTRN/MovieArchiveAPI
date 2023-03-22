﻿using MovieArchive.Models;

namespace MovieArchive.Interfaces;

public interface IMovieRepository
{
    Task<List<Movie>> GetAllMovies();
    Task<Movie>? GetMovieByName(string name);
    Task Create(Movie movie);
    Task UpdateMovie(string name,Movie updatedMovie);
    Task DeleteMovie(string name);
   
}