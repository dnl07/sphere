using Sphere.Application.UseCases.ClothingItems.Commands.Create;
using Sphere.Application.UseCases.ClothingItems.Commons;
using Sphere.Application.UseCases.Search.Command.Search;
using Sphere.Domain.ClothingItems;

namespace Sphere.Application.Mappers.ClothingItems {
    public static class ClothingItemMapper {
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

        public static ClothingItemDto ToDto(this ClothingItem item, string categoryName) {
            return new ClothingItemDto {
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

        public static SearchResultItem ToSearchResult(this ClothingItem item, string? categoryName) {
            return new SearchResultItem(
                item.Id,
                item.Name,
                categoryName,
                item.Description,
                item.Size,
                item.Material,
                item.Color,
                item.Price?.Amount,
                item.Price?.Currency,
                item.ImageId
            );
        }
    }
}
