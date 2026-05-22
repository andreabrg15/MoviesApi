namespace MoviesApi.Dtos
{
    public record MovieDetailsDto
    (
        int Id,
        string Title,
        string Description,
        int GenreId,
        DateOnly ReleaseDate
    );
}
