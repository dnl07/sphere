using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.UseCases.ClothingItem.Queries.GetMeta {
    public record ClothingItemMeta(
        int TotalItems,
        CategoryCount[] AvailableCategories,
        ColorCount[] AvailableColors,
        SizeCount[] AvailableSizes,
        MaterialCount[] AvailableMaterials,
        decimal? MinPrice,
        decimal? MaxPrice
    );

    public record CategoryCount(string Category, int Count);
    public record ColorCount(string Color, int Count);
    public record SizeCount(string Size, int Count);
    public record MaterialCount(string Material, int Count);
}
