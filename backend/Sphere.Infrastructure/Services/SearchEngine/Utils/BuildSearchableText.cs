using Sphere.Application.Commons.Models;
using Sphere.Domain.ClothingItems;

namespace Sphere.Infrastructure.Services.SearchEngine.Utils {
    public static class BuildSearchIndexItem {
        public static SearchIndexItem ToSearchableText(this ClothingItem item, string categoryName) {
            var tags = new[] {
                categoryName,
                item.Size,
                item.Material,
                item.Color,
            }
            .Where(t => !string.IsNullOrWhiteSpace(t))
            .Cast<string>()
            .ToArray();

            return new SearchIndexItem {
                Id = item.Id,
                Title = item.Name,
                Tags = tags
            };
        }
    }
}
