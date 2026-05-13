namespace Sphere.Api.Dtos.Requests.ClothingItems {
    public interface IClothingFilter {
        string[]? CategoryNames { get; set; }
        string[]? Colors { get; set; }
        string[]? Sizes { get; set; }
        string[]? Materials { get; set; }
    }
}
