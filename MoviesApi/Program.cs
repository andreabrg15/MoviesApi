using MoviesApi.Data;
using MoviesApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.AddMovieDb();

var app = builder.Build();

app.MapMoviesEndpoints();

app.MapGenresEndpoints();

app.MigrateDb();

app.Run();
