using Sphere.Domain.Images;

namespace Sphere.Domain.ClothingImages {
    public static class ImageValidator {
        public static void Validate(this Image item) {
            if (String.IsNullOrWhiteSpace(item.FileName)) {
                throw new Exception("Name of clothing can not be empty");
            }
        }
    }
}
