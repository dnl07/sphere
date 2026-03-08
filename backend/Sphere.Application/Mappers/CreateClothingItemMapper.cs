using Sphere.Application.UseCases.ClothingItems.Commands.Create;
using Sphere.Domain.Clothing;
using Sphere.Domain.Clothing.ValueObjects;
using Sphere.Domain.Images;

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
                new Price(cmd.PriceAmount ?? 0, cmd.Currency ?? "EUR"),
                new Image(cmd.ImageFileName, cmd.Image.Length, cmd.ImageContentType)
            );
        }

        public static CreateClothingItemResponse ToCreateResponse(this ClothingItem item) {
            return new CreateClothingItemResponse(
                item.Id,
                item.Name,
                item.Category,
                item.Description,
                item.Size,
                item.Material,
                item.Color,
                item.Price?.Amount,
                item.Price?.Currency,
                item.Image.Id
            );
        }
    }
}
