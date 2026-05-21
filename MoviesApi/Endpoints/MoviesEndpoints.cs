using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;
using MoviesApi.Models;

namespace MoviesApi.Endpoints
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
                return Results.Created($"/movies/{movie.Id}", movie);
            });

            // PUT /movies/{id}
            group.MapPut("/{id}", async (int id, Movie updatedMovie, MovieDb db) =>
            {
                var existingMovie = await db.Movies.FindAsync(id);

                if (existingMovie is null)
                {
                    return Results.NotFound();
                }

                existingMovie.Title = updatedMovie.Title;
                existingMovie.Description = updatedMovie.Description;
                existingMovie.Genre = updatedMovie.Genre;
                existingMovie.ReleaseDate = updatedMovie.ReleaseDate;

                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            // DELETE /movies/{id}
            group.MapDelete("/{id}", async (int id, MovieDb db) =>
            {
                var movie = await db.Movies.FindAsync(id);

                if (movie is null)
                {
                    return Results.NotFound();
                }

                db.Movies.Remove(movie);
                await db.SaveChangesAsync();

                return Results.NoContent();
            });
        }
    }
}
