using Sphere.Application.UseCases.ClothingItems.Queries.Get;
using Sphere.Domain.Clothing;

namespace Sphere.API.Mappers {
    public static class GetClothingItemMapper {
        public static GetClothingItemResponse ToGetResponse(this ClothingItem item) {
            return new GetClothingItemResponse(
                item.Id,
                item.Name,
                item.Category,
                item.Description,
                item.Size,
                item.Material,
                item.Color,
                item.Price,
                item.ImageId,
                item.CreatedAt,
                item.UpdatedAt
            );
        }
    }
}
