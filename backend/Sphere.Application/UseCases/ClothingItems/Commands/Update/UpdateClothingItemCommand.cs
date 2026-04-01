using Sphere.Application.Commons.Interfaces;
using Sphere.Application.UseCases.ClothingItems.Commons;

namespace Sphere.Application.UseCases.ClothingItems.Commands.Update {
    public class UpdateClothingItemCommand(
        Guid id,
        string? name,
        string? category,
        string? size,
        string? material,
        string? color,
        decimal? amount,
        string? currency,
        DateTime? boughtAt,
        string? store,
        string? brand,
        bool isArchived,
        string? notes,
        byte[]? image,
        string? imageFileName,
        string? imageContentType) : IUseCase<ClothingItemDto> {
        public Guid Id { get; set; } = id;
        public string? Name { get; set; } = name;
        public string? Category { get; set; } = category;
        public string? Size { get; set; } = size;
        public string? Material { get; set; } = material;
        public string? Color { get; set; } = color;
        public decimal? PriceAmount { get; set; } = amount;
        public string? Currency { get; set; } = currency;
        public DateTime? BoughtAt { get; set; } = boughtAt;
        public string? Store { get; set; } = store;
        public string? Brand { get; set; } = brand;
        public bool IsArchived { get; set; } = isArchived;
        public string? Notes { get; set; } = notes;
        public byte[]? Image { get; set; } = image ?? [];
        public string? ImageFileName { get; set; } = imageFileName;
        public string? ImageContentType { get; set; } = imageContentType;
    }
}
