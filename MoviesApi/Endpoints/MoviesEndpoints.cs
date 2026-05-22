using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;
using MoviesApi.Dtos;
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
                var movies = await db.Movies
                .Include(m => m.Genre)
                .Select(m => new MovieSummaryDto(
                    m.Id,
                    m.Title,
                    m.Description,
                    m.Genre.Name,
                    m.ReleaseDate
                ))
                .AsNoTracking()
                .ToListAsync();
                return Results.Ok(movies);
            });

            // GET /movies/{id}
            group.MapGet("/{id}", async (int id, MovieDb db) =>
            {
                var movie = await db.Movies.FindAsync(id);
                return movie is null ? Results.NotFound() : Results.Ok(
                    new MovieDetailsDto(
                        movie.Id,
                        movie.Title,
                        movie.Description,
                        movie.GenreId,
                        movie.ReleaseDate
                    )
                );
            }).WithName("GetMovie");

            // POST /movies
            group.MapPost("/", async (CreateMovieDto newMovie, MovieDb db) =>
            {
                Movie movie = new()
                {
                    Title = newMovie.Title,
                    Description = newMovie.Description,
                    GenreId = newMovie.GenreId,
                    ReleaseDate = newMovie.ReleaseDate
                };

                db.Movies.Add(movie);
                await db.SaveChangesAsync();

                MovieDetailsDto movieDto = new(
                    movie.Id,
                    movie.Title,
                    movie.Description,
                    movie.GenreId,
                    movie.ReleaseDate
                );

                return Results.CreatedAtRoute("GetMovie", new { id = movieDto.Id }, movieDto);
            });

            // PUT /movies/{id}
            group.MapPut("/{id}", async (int id, UpdateMovieDto updatedMovie, MovieDb db) =>
            {
                var existingMovie = await db.Movies.FindAsync(id);

                if (existingMovie is null)
                {
                    return Results.NotFound();
                }

                existingMovie.Title = updatedMovie.Title;
                existingMovie.Description = updatedMovie.Description;
                existingMovie.GenreId = updatedMovie.GenreId;
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
