namespace Sphere.Domain.ClothingItems {
    public partial class ClothingItem {
        private void Validate() {
            if (string.IsNullOrWhiteSpace(Name)) {
                throw new InvalidOperationException("Name is required");
            }

            if (Category == null) {
                throw new InvalidOperationException("Category is required.");
            }
        }
    }
}
