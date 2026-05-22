namespace MoviesApi.Dtos
{
    public record MovieSummaryDto
    (
        int Id,
        string Title,
        string Description,
        string Genre,
        DateOnly ReleaseDate
    );
}
