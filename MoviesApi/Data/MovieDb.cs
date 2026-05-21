using Microsoft.EntityFrameworkCore;

namespace MoviesApi.Data
{
    public class MovieDb(DbContextOptions<MovieDb> options) : DbContext(options)
    {
        public DbSet<Movie> Movies => Set<Movie>();
    }
}
