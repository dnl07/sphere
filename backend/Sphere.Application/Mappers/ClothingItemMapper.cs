using Sphere.Application.ClothingItems.Commands.Create;
using Sphere.Domain.Clothing;

namespace Sphere.API.Mappers {
    public static class ClothingItemMapper {
        public static ClothingItem ToDomain(this CreateClothingItemCommand command) {
            return new ClothingItem(
                command.Name,
                command.Type
            );
        }

        public static CreateClothingItemResponse ToResponse(this ClothingItem item) {
            return new CreateClothingItemResponse(
                item.Name,
                item.Type
            );
        }
    }
}
