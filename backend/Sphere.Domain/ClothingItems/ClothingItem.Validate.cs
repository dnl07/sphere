using Sphere.Domain.ClothingItems.Exceptions;

namespace Sphere.Domain.ClothingItems {
    public partial class ClothingItem {
        private void Validate() {
            if (Price.HasValue && Price < 0) {
                throw new InvalidPriceException(Price.Value);
            }
        }
    }
}
