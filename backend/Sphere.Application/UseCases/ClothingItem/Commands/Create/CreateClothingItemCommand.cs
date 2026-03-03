using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.UseCases.ClothingItems.Commands.Create {
    public class CreateClothingItemCommand : IUseCase<CreateClothingItemResponse> {
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

        public CreateClothingItemCommand(string name, 
            string category, 
            string? description, 
            string? size, 
            string? material, 
            string? color, 
            decimal? amount,
            string? currency,
            byte[] image,
            string imageFileName,
            string imageContentType) {
            Name = name ?? "";
            Category = category ?? "";
            Description = description ?? "";
            Size = size ?? "";
            Material = material ?? "";
            Color = color ?? "";
            PriceAmount = amount;
            Currency = currency ?? "EUR";
            Image = image ?? [];
            ImageFileName = imageFileName ?? "";
            ImageContentType = imageContentType ?? "";
        }
    }
}
