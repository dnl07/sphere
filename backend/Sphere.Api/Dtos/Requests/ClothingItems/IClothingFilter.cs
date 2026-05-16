namespace Sphere.Api.Dtos.Requests.ClothingItems {
    public interface IClothingFilter {
        string[]? Categories { get; set; }
        string[]? Colors { get; set; }
        string[]? Sizes { get; set; }
        string[]? Materials { get; set; }
        string[]? Brands { get; set; }
        string[]? Stores { get; set; }
        decimal? PriceMin { get; set; }
        decimal? PriceMax { get; set; }
    }
}
