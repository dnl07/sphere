using Sphere.Application.UseCases.ClothingItems.Queries.Get;
using Sphere.Domain.ClothingItems;

namespace Sphere.Application.Mappers.ClothingItems {
    public static class GetClothingItemMapper {
        public static GetByIdResponse ToGetResponse(this ClothingItem item, string categoryName) {
            return new GetByIdResponse {
                Id = item.Id,
                Name = item.Name,
                Category = categoryName,
                Description = item.Description,
                Size = item.Size,
                Material = item.Material,
                Color = item.Color,
                Price = item.Price?.ToDto(),
                ImageId = item.ImageId,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt
            };
        }
    }
}
