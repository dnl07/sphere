using Sphere.Application.Commons.Models;

namespace Sphere.Application.UseCases.ClothingItem.Queries.GetFiltered {
    public class ClothingItemFilter : PagedFilter {
        public Guid[]? CategoryIds { get; set; }
        public string[]? Color { get; set; }
        public string[]? Size { get; set; }
        public string[]? Material { get; set; }
    }
}