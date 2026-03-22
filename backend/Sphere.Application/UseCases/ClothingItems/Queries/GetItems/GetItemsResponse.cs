using Sphere.Application.Commons.Models;
using Sphere.Application.UseCases.ClothingItems.Commons;

namespace Sphere.Application.UseCases.ClothingItems.Queries.GetItems {
    public class GetItemsResponse {
        public PagedResult<ClothingItemDto> Paged { get; set; }
        public ClothingItemMeta Meta { get; set; }

        public GetItemsResponse(PagedResult<ClothingItemDto> paged, ClothingItemMeta meta) {
            Paged = paged;
            Meta = meta;
        }

        public static GetItemsResponse Empty => 
            new GetItemsResponse(new PagedResult<ClothingItemDto>(), ClothingItemMeta.Empty);
    }
}
