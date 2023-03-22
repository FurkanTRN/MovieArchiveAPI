namespace MovieArchive.Models;

public class MovieArchiveDbSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string MovieCollectionName { get; set; } = null!;
}