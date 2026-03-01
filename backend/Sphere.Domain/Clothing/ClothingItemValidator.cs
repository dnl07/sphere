using Sphere.Domain.Clothing.Exceptions;

namespace Sphere.Domain.Clothing {
    public static  class ClothingItemValidator {
        public static void Validate(this ClothingItem item) {
            if (String.IsNullOrWhiteSpace(item.Name)) {
                throw new InvalidClothingException("Name of clothing can not be empty");
            }
        }
    }
}
