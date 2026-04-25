using Sphere.Api.Dtos.Requests.Commons;
using Sphere.Application.UseCases.ClothingItems.Commons;

namespace Sphere.Api.Dtos.Requests.ClothingItems {
    public class ClothingItemFilterRequest : PagedRequest {
        public string? SearchQuery { get; set; }
        public string[]? CategoryNames { get; set; }
        public string[]? Colors { get; set; }
        public string[]? Sizes { get; set; }
        public string[]? Materials { get; set; }
        public ClothingItemSortOrder? SortBy { get; set; }
    }
}