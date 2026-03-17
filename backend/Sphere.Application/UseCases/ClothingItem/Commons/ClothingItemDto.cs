namespace Sphere.Application.UseCases.ClothingItems.Queries.GetAll {
    public record ClothingItemDto(
        string Name,
        string Category,
        string? Description,
        string? Size,
        string? Material,
        string? Color,
        decimal? PriceAmount,
        string? Currency,
        byte[] Image,
        string ImageFileName,
        string ImageContentType
    );
}
