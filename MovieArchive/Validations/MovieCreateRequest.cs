using System.ComponentModel.DataAnnotations;

namespace MovieArchive.Validations;

public class MovieCreateRequest
{
    [Required] public string MovieName { get; set; } = null!;

    [Required] [Range(1900, 2100)] public int ReleaseYear { get; set; }
    [Required] public string Category { get; set; } = null!;

    [Range(0, 10)] [Required] public double Point { get; set; }
    [StringLength(500)] public string? Note { get; set; }
}