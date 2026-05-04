using Sphere.Domain.ClothingItems.ValueObjects;

namespace Sphere.Domain.ClothingItems {
    public partial class ClothingItem {
        public void Update(
            string? name = null,
            Guid? categoryId = null,
            string? size = null,
            string? material = null,
            string? color = null,
            decimal? priceAmount = null,
            string? currency = null,
            DateTime? boughtAt = null,
            string? store = null,
            string? brand = null,
            bool? isArchived = null,
            string? notes = null,
            Guid? imageId = null) {

            if (categoryId is not null) {
                CategoryId = categoryId.Value;
            }

            if (size is not null) {
                Size = size;
            }

            if (material is not null) {
                Material = material;
            }

            if (color is not null) {
                Color = color;
            }

            priceAmount ??= Price?.Amount;
            currency ??= Price?.Currency;

            if (priceAmount is not null && currency is not null) {
                Price = new Price(priceAmount.Value, currency);
            }

            if (boughtAt is not null) {
                BoughtAt = boughtAt.Value;
            }

            if (store is not null) {
                Store = store;
            }

            if (brand is not null) {
                Brand = brand;
            }

            if (isArchived is not null) {
                IsArchived = isArchived.Value;
            }

            if (notes is not null) {
                Notes = notes;
            }

            if (imageId is not null) {
                ImageId = imageId.Value;
            }

            Validate();
        }
    }
}
