using MovieArchive.Interfaces;
using MovieArchive.Models;
using MovieArchive.Repository;
using MovieArchive.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MovieArchiveDbSettings>(builder.Configuration.GetSection("MovieArchiveDatabase"));
builder.Services.AddTransient<IMovieRepository,MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();