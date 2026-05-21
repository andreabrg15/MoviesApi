using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;

namespace MoviesApi.Endpoints
{
    public static class GenresEndpoints
    {
        public static void MapGenresEndpoints(this WebApplication app)
        {
            // GET /genres
            app.MapGet("/genres", async (MovieDb db) =>
            {
                var genres = await db.Genres.ToListAsync();
                return Results.Ok(genres);
            });
        }
    }
}
