using Sphere.Domain.Categories;
using Sphere.Domain.Clothing.ValueObjects;

namespace Sphere.Application.UseCases.ClothingItems.Queries.Get {
    public class GetClothingItemResponse {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string? Description { get; set; }
        public string? Size { get; set; }
        public string? Material { get; set; }
        public string? Color { get; set; }
        public Price? Price { get; set; }
        public Guid ImageId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public GetClothingItemResponse(
            Guid id,
            string name,
            string category,
            string? description,
            string? size,
            string? material,
            string? color,
            Price? price,
            Guid imageId,
            DateTime createdAt,
            DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Category = category;
            Description = description;
            Size = size;
            Material = material;
            Color = color;
            Price = price;
            ImageId = imageId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
