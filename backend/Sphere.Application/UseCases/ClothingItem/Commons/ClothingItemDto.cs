namespace Sphere.Application.UseCases.ClothingItem.Commons {
    public class ClothingItemDto {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public string? Category { get; init; }
        public string? Description { get; init; }
        public string? Size { get; init; }
        public string? Material { get; init; }
        public string? Color { get; init; }
        public PriceDto? Price { get; init; }
        public Guid ImageId { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
    }

    public record PriceDto(decimal Amount, string Currency);
}
