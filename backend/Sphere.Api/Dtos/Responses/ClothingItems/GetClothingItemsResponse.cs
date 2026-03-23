using Sphere.Application.UseCases.ClothingItems.Commons;

namespace Sphere.Api.Dtos.Responses.ClothingItems {
    public class GetClothingItemsResponse {
        public List<ClothingItemDto> Items { get; set; } = [];
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public ClothingItemFilterResponse? Filters { get; set; }
    }
}
