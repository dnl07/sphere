namespace Sphere.Domain.ClothingImages {
    public static class ClothingImageValidator {
        public static void Validate(this ClothingImage item) {
            if (String.IsNullOrWhiteSpace(item.FileName)) {
                throw new Exception("Name of clothing can not be empty");
            }
        }
    }
}
