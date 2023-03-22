﻿using MovieArchive.Interfaces;
using MovieArchive.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MovieArchive.Repository;

public class MovieRepository : IMovieRepository
{   
    private readonly IMongoCollection<Movie> _moviceCollection;

    public MovieRepository(IOptions<MovieArchiveDbSettings> movieArchiveDbSettings)
    {
        var mongoClient = new MongoClient(
            movieArchiveDbSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(
            movieArchiveDbSettings.Value.DatabaseName);

        _moviceCollection = mongoDatabase.GetCollection<Movie>(
            movieArchiveDbSettings.Value.MovieCollectionName);
    }
    
    public async Task<List<Movie>> GetAllMovies()
    {
        return await _moviceCollection.Find(_ => true).ToListAsync();
    }

    public async Task<Movie>? GetMovieByName(string name)
    {
        return await _moviceCollection.Find(x => x.MovieName == name).FirstOrDefaultAsync();
    }

    public async Task Create(Movie newMovie)
    {
        await _moviceCollection.InsertOneAsync(newMovie);
    }

    public async Task UpdateMovie(string name,Movie updatedMovie)
    {
        await _moviceCollection.ReplaceOneAsync(x => x.MovieName == name, updatedMovie);
    }

    public async Task DeleteMovie(string name)
    {
        await _moviceCollection.DeleteOneAsync(x => x.MovieName == name);
    }

   
}