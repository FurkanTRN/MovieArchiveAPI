using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MovieArchive.Validations;

public class MovieUpdateRequest
{
    public string MovieName { get; set; } 
    [Range(0, 10)] public double Point { get; set; }
    [StringLength(500)] public string? Note { get; set; }
    public string? Category { get; set; }
    [Range(1900, 2100)] public int ReleaseYear { get; set; }
    
}