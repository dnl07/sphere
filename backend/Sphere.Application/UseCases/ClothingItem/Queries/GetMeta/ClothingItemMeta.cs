using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.UseCases.ClothingItem.Queries.GetMeta {
    public record ClothingItemMeta(
        int TotalItems,
        string[] AvailableCategories,
        string[] AvailableColors,
        string[] AvailableSizes,
        string[] AvailableMaterials,
        decimal? MinPrice,
        decimal? MaxPrice
    );
}
