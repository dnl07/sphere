using Sphere.Application.UseCases.ClothingItems.Queries.Get;
using Sphere.Domain.ClothingItems;

namespace Sphere.Application.Mappers {
    public static class GetClothingItemMapper {
        public static GetClothingItemResponse ToGetResponse(this ClothingItem item, string categoryName) {
            return new GetClothingItemResponse(
                item.Id,
                item.Name,
                categoryName,
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
