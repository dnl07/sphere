using Sphere.Api.Dtos.Requests.Commons;

namespace Sphere.Api.Dtos.Requests.ClothingItems {
    public class ClothingItemFilterRequest : PagedRequest {
        public Guid[]? CategoryIds { get; set; }
        public string[]? Color { get; set; }
        public string[]? Size { get; set; }
        public string[]? Material { get; set; }

        public bool IsEmpty() {
            return (CategoryIds == null || CategoryIds.Length == 0) &&
                   (Color == null || Color.Length == 0) &&
                   (Size == null || Size.Length == 0) &&
                   (Material == null || Material.Length == 0);
        }
    }
}