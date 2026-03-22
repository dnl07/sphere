namespace Sphere.Application.UseCases.ClothingItems.Commons {
    public class ClothingItemMeta {
        public FilterOption[] AvailableCategories { get; set; } = [];
        public FilterOption[] AvailableColors { get; set; } = [];
        public FilterOption[] AvailableSizes { get; set; } = [];
        public FilterOption[] AvailableMaterials { get; set; } = [];
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public ClothingItemMeta(FilterOption[] availableCategories, FilterOption[] availableColors, FilterOption[] availableSizes, FilterOption[] availableMaterials, decimal? minPrice, decimal? maxPrice) {
            AvailableCategories = availableCategories;
            AvailableColors = availableColors;
            AvailableSizes = availableSizes;
            AvailableMaterials = availableMaterials;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
        }

        public static ClothingItemMeta Empty => new ClothingItemMeta([], [], [], [], null, null);
    }

    public record FilterOption(string Name, int Count);
}
