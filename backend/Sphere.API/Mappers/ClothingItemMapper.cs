using Sphere.API.Dtos.Requests;
using Sphere.Application.ClothingItems.Commands.Create;

namespace Sphere.API.Mappers {
    public static class ClothingItemMapper {
        public static CreateClothingItemCommand ToCommand(this CreateClothingItemRequestDto request) {
            return new CreateClothingItemCommand(
                request.Name,
                request.Type
            );
        }
    }
}
