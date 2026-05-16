namespace Sphere.Api.Dtos.Requests.ClothingItems {
    public class ClothingItemCountRequest : IClothingFilter {
        public string[]? Categories { get; set; }
        public string[]? Colors { get; set; }
        public string[]? Sizes { get; set; }
        public string[]? Materials { get; set; }
        public string[]? Brands { get; set; }
        public string[]? Stores { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
    }
}