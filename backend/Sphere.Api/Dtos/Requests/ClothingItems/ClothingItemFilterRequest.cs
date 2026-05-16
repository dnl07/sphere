using Sphere.Api.Dtos.Requests.Commons;
using Sphere.Application.UseCases.ClothingItems.Commons;

namespace Sphere.Api.Dtos.Requests.ClothingItems {
    public class ClothingItemFilterRequest : PagedRequest, IClothingFilter {
        public string? SearchQuery { get; set; }
        public string[]? Categories { get; set; }
        public string[]? Colors { get; set; }
        public string[]? Sizes { get; set; }
        public string[]? Materials { get; set; }
        public string[]? Brands { get; set; }
        public string[]? Stores { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
        public ClothingItemSortOrder? SortBy { get; set; }
    }
}