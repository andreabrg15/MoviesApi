using Microsoft.EntityFrameworkCore;

namespace MoviesApi.Data
{
    public static class DataExtensions
    {
        public static void MigrateDb(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MovieDb>();
            context.Database.Migrate();
        }

        public static void AddMovieDb(this WebApplicationBuilder builder)
        {
            var connString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddSqlServer<MovieDb>(connString);
        }
    }
}
