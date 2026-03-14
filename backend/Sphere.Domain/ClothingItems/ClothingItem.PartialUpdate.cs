using Sphere.Domain.ClothingItems.ValueObjects;

namespace Sphere.Domain.ClothingItems {
    public partial class ClothingItem {
        public void Update(
            string? name = null,
            Guid? categoryId = null,
            string? description = null,
            string? size = null,
            string? material = null,
            string? color = null,
            decimal? priceAmount = null,
            string? currency = null,
            Guid? imageId = null) {
            if (name != null) {
                Name = name;
            }

            if (categoryId is not null) {
                CategoryId = categoryId.Value;
            }

            if (description is not null) {
                Description = description;
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

            if (imageId is not null) {
                ImageId = imageId.Value;
            }

            Validate();
        }
    }
}
