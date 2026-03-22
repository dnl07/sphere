using Sphere.Application.Commons.Interfaces;
using Sphere.Application.UseCases.ClothingItem.Commons;

namespace Sphere.Application.UseCases.ClothingItem.Commands.Update {
    public class UpdateClothingItemCommand(
        Guid id,
        string? name,
        string? category,
        string? description,
        string? size,
        string? material,
        string? color,
        decimal? amount,
        string? currency,
        byte[]? image,
        string? imageFileName,
        string? imageContentType) : IUseCase<ClothingItemDto> {
        public Guid Id { get; set; } = id;
        public string? Name { get; set; } = name;
        public string? Category { get; set; } = category;
        public string? Description { get; set; } = description;
        public string? Size { get; set; } = size;
        public string? Material { get; set; } = material;
        public string? Color { get; set; } = color;
        public decimal? PriceAmount { get; set; } = amount;
        public string? Currency { get; set; } = currency;

        public byte[]? Image { get; set; } = image ?? [];
        public string? ImageFileName { get; set; } = imageFileName;
        public string? ImageContentType { get; set; } = imageContentType;
    }
}
