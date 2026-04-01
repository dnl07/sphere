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
                cmd.Size,
                cmd.Material,
                cmd.Color,
                cmd.PriceAmount,
                cmd.Currency,
                cmd.BoughtAt,
                cmd.Store,
                cmd.Brand,
                cmd.IsArchived,
                cmd.Notes,
                imageId
            );
        }

        public static ClothingItemDto ToDto(this ClothingItem item, string categoryName) {
            return new ClothingItemDto {
                Id = item.Id,
                Name = item.Name,
                Category = categoryName,
                Size = item.Size,
                Material = item.Material,
                Color = item.Color,
                Price = item.Price?.ToDto(),
                BoughtAt = item.BoughtAt,
                Store = item.Store,
                Brand = item.Brand,
                IsArchived = item.IsArchived,
                Notes = item.Notes,
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
