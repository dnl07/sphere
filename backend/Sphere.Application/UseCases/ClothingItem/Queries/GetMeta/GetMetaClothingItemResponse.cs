using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.UseCases.ClothingItem.Queries.GetMeta {
    public record GetMetaClothingItemResponse(
        int TotalItems,
        CategoryCount[] AvailableCategories,
        ColorCount[] AvailableColors,
        SizeCount[] AvailableSizes,
        MaterialCount[] AvailableMaterials,
        decimal? MinPrice,
        decimal? MaxPrice
    );
}
