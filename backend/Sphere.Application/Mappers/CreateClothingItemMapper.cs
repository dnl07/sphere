using Sphere.Application.UseCases.ClothingItems.Commands.Create;
using Sphere.Domain.Clothing;
using Sphere.Domain.Clothing.ValueObjects;
using Sphere.Domain.ClothingImages;

namespace Sphere.API.Mappers {
    public static class CreateClothingItemMapper {
        public static ClothingItem ToDomain(this CreateClothingItemCommand cmd) {
            return new ClothingItem(
                cmd.Name,
                cmd.Category,
                cmd.Description,
                cmd.Size,
                cmd.Material,
                cmd.Color,
                new Price(cmd.PriceAmount, cmd.Currency),
                new ClothingImage(cmd.ImageFileName, cmd.Image.Length, cmd.ImageContentType)
            );
        }

        public static CreateClothingItemResponse ToCreateResponse(this ClothingItem item) {
            return new CreateClothingItemResponse(
                item.Id,
                item.Name
            );
        }
    }
}
