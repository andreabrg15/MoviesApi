using MoviesApi;
using MoviesApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.AddMovieDb();

var app = builder.Build();

app.MapGet("/movies/{id}", async (int id, MovieDb db) =>
{
    var movie = await db.Movies.FindAsync(id);
    return movie is not null ? Results.Ok(movie) : Results.NotFound();
});

app.MapPost("/movies", async (Movie movie, MovieDb db) =>
{
    db.Movies.Add(movie);
    await db.SaveChangesAsync();
    return Results.CreatedAtRoute("/movies", new {id = movie.Id}, movie);
});

app.MigrateDb();

app.Run();
