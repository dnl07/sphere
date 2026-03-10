using Sphere.Api.Dtos.Validation;
using System.ComponentModel.DataAnnotations;

namespace Sphere.Api.Dtos.Requests {
    public class CreateInferenceRequestDto {
        [Required(ErrorMessage = "Image is required")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        [MaxFileSize(5 * 1024 * 1024)]
        public IFormFile Image { get; set; } = null!;
    }
}
