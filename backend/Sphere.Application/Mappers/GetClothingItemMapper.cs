using Sphere.Application.UseCases.ClothingItems.Commands.Get;
using Sphere.Domain.Clothing;

namespace Sphere.API.Mappers {
    public static class GetClothingItemMapper {
        public static GetClothingItemResponse ToGetResponse(this ClothingItem item) {
            return new GetClothingItemResponse(
                item.Id,
                item.Name
            );
        }
    }
}
