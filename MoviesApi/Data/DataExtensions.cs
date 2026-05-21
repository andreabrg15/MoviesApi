using Microsoft.EntityFrameworkCore;
using MoviesApi.Models;

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
            builder.Services.AddSqlServer<MovieDb>(
                connString, 
                optionsAction: options => options.UseSeeding((context, _) =>
                {
                    if (!context.Set<Genre>().Any())
                    {
                        context.Set<Genre>().AddRange(
                            new Genre { Name = "Action" },
                            new Genre { Name = "Sci-Fi" },
                            new Genre { Name = "Drama" },
                            new Genre { Name = "Comedy" },
                            new Genre { Name = "Thriller" },
                            new Genre { Name = "Horror" },
                            new Genre { Name = "Romance" },
                            new Genre { Name = "Romantic Comedy" },
                            new Genre { Name = "Fantasy" }
                         );

                        context.SaveChanges();

                    }
                })
            );
        }
    }
}
