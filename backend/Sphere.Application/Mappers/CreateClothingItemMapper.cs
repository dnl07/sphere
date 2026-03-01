using Sphere.Application.UseCases.ClothingItems.Commands.Create;
using Sphere.Domain.Clothing;

namespace Sphere.API.Mappers {
    public static class CreateClothingItemMapper {
        public static ClothingItem ToDomain(this CreateClothingItemCommand command) {
            return new ClothingItem(
                command.Name,
                command.Type
            );
        }

        public static CreateClothingItemResponse ToCreateResponse(this ClothingItem item) {
            return new CreateClothingItemResponse(
                item.Id,
                item.Name,
                item.Type
            );
        }
    }
}
