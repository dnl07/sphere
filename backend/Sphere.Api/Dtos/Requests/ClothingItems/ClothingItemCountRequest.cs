namespace Sphere.Api.Dtos.Requests.ClothingItems {
    public class ClothingItemCountRequest : IClothingFilter {
        public string[]? CategoryNames { get; set; }
        public string[]? Colors { get; set; }
        public string[]? Sizes { get; set; }
        public string[]? Materials { get; set; }
    }
}