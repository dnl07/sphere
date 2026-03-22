using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.UseCases.ClothingItem.Commons {
    public class ClothingItemMeta {
        public int TotalItems { get; set; }
        public CategoryCount[] AvailableCategories { get; set; } = new CategoryCount[0];
        public ColorCount[] AvailableColors { get; set; } = new ColorCount[0];
        public SizeCount[] AvailableSizes { get; set; } = new SizeCount[0];
        public MaterialCount[] AvailableMaterials { get; set; } = new MaterialCount[0];
        public decimal? MinPrice { get; set; }
        public decimal? MaxPric { get; set; }

        public ClothingItemMeta(int totalItems, CategoryCount[] availableCategories, ColorCount[] availableColors, SizeCount[] availableSizes, MaterialCount[] availableMaterials, decimal? minPrice, decimal? maxPric) {
            TotalItems = totalItems;
            AvailableCategories = availableCategories;
            AvailableColors = availableColors;
            AvailableSizes = availableSizes;
            AvailableMaterials = availableMaterials;
            MinPrice = minPrice;
            MaxPric = maxPric;
        }

        public static ClothingItemMeta Empty => new ClothingItemMeta(
            0,
            Array.Empty<CategoryCount>(),
            Array.Empty<ColorCount>(),
            Array.Empty<SizeCount>(),
            Array.Empty<MaterialCount>(),
            null,
            null
        );
    }

    public record CategoryCount(string Category, int Count);
    public record ColorCount(string Color, int Count);
    public record SizeCount(string Size, int Count);
    public record MaterialCount(string Material, int Count);
}
