using Sphere.Application.UseCases.ClothingItems.Commands.Create;
using Sphere.Domain.ClothingItems;

namespace Sphere.Application.Mappers {
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
            return new CreateClothingItemResponse(
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
