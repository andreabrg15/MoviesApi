using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;

namespace MoviesApi
{
    public static class MoviesEndpoints
    {
        public static void MapMoviesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/movies");

            // GET /movies
            group.MapGet("/", async (MovieDb db) =>
            {
                var movies = await db.Movies.ToListAsync();
                return Results.Ok(movies);
            });

            // GET /movies/{id}
            group.MapGet("/{id}", async (int id, MovieDb db) =>
            {
                var movie = await db.Movies.FindAsync(id);
                return movie is not null ? Results.Ok(movie) : Results.NotFound();
            });

            // POST /movies
            group.MapPost("/", async (Movie movie, MovieDb db) =>
            {
                db.Movies.Add(movie);
                await db.SaveChangesAsync();
                return Results.CreatedAtRoute("/movies", new { id = movie.Id }, movie);
            });
        }
    }
}
