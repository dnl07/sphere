using Sphere.Application.UseCases.ClothingItems.Commons;

namespace Sphere.Api.Dtos.Responses.ClothingItems {
    public class ClothingItemFilterResponse {
        public FilterOption[]? Categories { get; set; }
        public FilterOption[]? Colors { get; set; }
        public FilterOption[]? Sizes { get; set; }
        public FilterOption[]? Materials { get; set; }
        public PriceRange? PriceRange { get; set; }
    }

    public class PriceRange {
        public decimal? Min { get; set; }
        public decimal? Max { get; set; }
    }
}
