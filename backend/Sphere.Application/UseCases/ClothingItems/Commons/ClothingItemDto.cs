namespace Sphere.Application.UseCases.ClothingItems.Commons {
    public class ClothingItemDto {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public string? Category { get; init; }
        public string? Size { get; init; }
        public string? Material { get; init; }
        public string? Color { get; init; }
        public PriceDto? Price { get; init; }
        public DateTime? BoughtAt { get; init; }
        public string? Store { get; init; }
        public string? Brand { get; init; }
        public bool IsArchived { get; init; }
        public string? Notes { get; init; }
        public Guid ImageId { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
    }

    public record PriceDto(decimal Amount, string Currency);
}
