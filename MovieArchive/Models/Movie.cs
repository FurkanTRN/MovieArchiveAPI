using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MovieArchive.Models;

public class Movie
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    [BsonElement("Name")] public string MovieName { get; set; } = null!;

    public int ReleaseDate { get; set; }

    public string? Category { get; set; } = null!;
    
    public double Point { get; set; }
    
    public string? Note { get; set; }
}