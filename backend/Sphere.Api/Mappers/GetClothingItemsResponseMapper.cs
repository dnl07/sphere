using Sphere.Api.Dtos.Responses.ClothingItems;
using Sphere.Application.UseCases.ClothingItems.Queries.GetItems;

namespace Sphere.Api.Mappers {
    public static class GetClothingItemsResponseMapper {
        public static GetClothingItemsResponse ToResponse (this GetItemsResponse dto) {
            return new GetClothingItemsResponse {
                Items = dto.Paged.Items,
                TotalCount = dto.Paged.TotalCount,
                PageNumber = dto.Paged.PageNumber,
                HasNextPage = dto.Paged.HasNextPage,
                HasPreviousPage = dto.Paged.HasPreviousPage,
                Filters = new ClothingItemFilterResponse {
                    Categories = dto.Meta.AvailableCategories,
                    Colors = dto.Meta.AvailableColors,
                    Sizes = dto.Meta.AvailableSizes,
                    Materials = dto.Meta.AvailableMaterials,
                    PriceRange = new PriceRange {
                        Min = dto.Meta.MinPrice,
                        Max = dto.Meta.MaxPrice
                    }
                }
            };
        }
    }
}
