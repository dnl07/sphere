using Sphere.Application.Commons.Models;
using Sphere.Application.UseCases.ClothingItem.Commons;
using Sphere.Application.UseCases.ClothingItems.Queries.Get;

namespace Sphere.Application.UseCases.ClothingItem.Queries.GetItems {
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
