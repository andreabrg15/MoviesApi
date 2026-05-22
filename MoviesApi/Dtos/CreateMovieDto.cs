using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Dtos
{
    public record CreateMovieDto
    (
        [Required] [StringLength(50)] string Title,
        [StringLength(80)] string Description,
        int GenreId,
        DateOnly ReleaseDate
    );
}
