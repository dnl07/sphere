namespace Sphere.Api.Dtos.Requests {
    public class ClothingItemFilterRequest : PagedRequest {
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Color { get; set; }
    public string? Size { get; set; }
    public string? Material { get; set; }
    }
}