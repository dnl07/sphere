using Sphere.Application.UseCases.SearchEngine.Command.Search;
using Sphere.Domain.ClothingItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.Mappers.ClothingItems {
    public static class ClothingItemMapper {
        public static SearchResultItem ToSearchResult(this ClothingItem item, string? categoryName) {
            return new SearchResultItem(
                item.Id,
                item.Name,
                categoryName,
                item.Description,
                item.Size,
                item.Material,
                item.Color,
                item.Price?.Amount,
                item.Price?.Currency,
                item.ImageId
            );
        }
    }
}
