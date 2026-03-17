namespace Sphere.Application.UseCases.ClothingItems.Queries.GetAll {
    public class ClothingItemDto {
        public string Name { get; set; }
        public string Category { get; set; }
        public string? Description { get; set; }
        public string? Size { get; set; }
        public string? Material { get; set; }
        public string? Color { get; set; }
        public decimal? PriceAmount { get; set; }
        public string? Currency { get; set; }

        public byte[] Image { get; set; } = [];
        public string ImageFileName { get; set; } = "";
        public string ImageContentType { get; set; } = "";
    }
}