using Sphere.Application.UseCases.ClothingItem.Commands.Update;
using Sphere.Application.UseCases.ClothingItems.Commands.Create;
using Sphere.Domain.Categories;
using Sphere.Domain.ClothingItems;
using Sphere.Domain.ClothingItems.ValueObjects;
using System.Drawing;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Sphere.Application.Mappers.ClothingItems {
    public static class CreateClothingItemMapper {
        public static ClothingItem ToDomain(this CreateClothingItemCommand cmd, Guid categoryId, Guid imageId) {
            return ClothingItem.Create(
                cmd.Name,
                categoryId,
                cmd.Description,
                cmd.Size,
                cmd.Material,
                cmd.Color,
                cmd.PriceAmount,
                cmd.Currency,
                imageId
            );
        }

        public static CreateClothingItemResponse ToCreateResponse(this ClothingItem item, string categoryName) {
            return new CreateClothingItemResponse {
                Id = item.Id,
                Name = item.Name,
                Category = categoryName,
                Description = item.Description,
                Size = item.Size,
                Material = item.Material,
                Color = item.Color,
                Price = item.Price?.ToDto(),
                ImageId = item.ImageId,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt
            };
        }

        public static UpdateClothingItemResponse ToUpdateResponse(this ClothingItem item, string categoryName) {
            return new UpdateClothingItemResponse {
                Id = item.Id,
                Name = item.Name,
                Category = categoryName,
                Description = item.Description,
                Size = item.Size,
                Material = item.Material,
                Color = item.Color,
                Price = item.Price?.ToDto(),
                ImageId = item.ImageId,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt
            };
        }
    }
}
