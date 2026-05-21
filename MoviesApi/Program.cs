using MoviesApi;
using MoviesApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.AddMovieDb();

var app = builder.Build();

app.MapMoviesEndpoints();

app.MigrateDb();

app.Run();
