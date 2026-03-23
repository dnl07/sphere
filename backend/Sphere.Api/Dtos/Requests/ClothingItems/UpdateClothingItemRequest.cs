using Sphere.Api.Dtos.Validation;
using System.ComponentModel.DataAnnotations;

namespace Sphere.Api.Dtos.Requests.ClothingItems {
    public class UpdateClothingItemRequest {
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string? Name { get; set; }

        [StringLength(50, ErrorMessage = "Category cannot be longer than 50 characters")]
        public string? Category { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string? Description { get; set; }

        [StringLength(20, ErrorMessage = "Size cannot be longer than 20 characters")]
        public string? Size { get; set; }

        [StringLength(50, ErrorMessage = "Material cannot be longer than 50 characters")]
        public string? Material { get; set; }

        [StringLength(50, ErrorMessage = "Color cannot be longer than 50 characters")]
        public string? Color { get; set; }

        [Range(0.01, 999999.99, ErrorMessage = "Price must be greater than 0 and less than 999999.99")]
        public decimal? PriceAmount { get; set; }

        [StringLength(3, ErrorMessage = "Currency cannot be longer than 3 characters")]
        public string? Currency { get; set; }

        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" })]
        [MaxFileSize(5 * 1024 * 1024)]
        public IFormFile? Image { get; set; } = null!;
    }
}
