using Sphere.Application.Commons.Models;

namespace Sphere.Application.UseCases.ClothingItems.Commons {
    public class ClothingItemFilter : PagedFilter {
        public Guid[]? CategoryIds { get; set; }
        public string[]? CategoryNames { get; set; }
        public string[]? Colors { get; set; }
        public string[]? Sizes { get; set; }
        public string[]? Materials { get; set; }
    }
}
