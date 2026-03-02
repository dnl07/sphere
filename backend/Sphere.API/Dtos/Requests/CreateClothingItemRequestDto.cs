namespace Sphere.API.Dtos.Requests {
    public class CreateClothingItemRequestDto {
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public string Description { get; set; } = "";
        public string Size { get; set; } = "";
        public string Material { get; set; } = "";
        public string Color { get; set; } = "";
        public decimal PriceAmount { get; set; } = 0;
        public string Currency { get; set; } = "";

        public IFormFile Image { get; set; } = null!;
    }
}
