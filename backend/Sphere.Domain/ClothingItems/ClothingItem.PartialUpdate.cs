using Sphere.Domain.Categories;
using Sphere.Domain.Clothing.ValueObjects;
using Sphere.Domain.MediaFiles;

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

            if (description != null) {
                Description = description;
            }

            if (size != null) {
                Size = size;
            }

            if (material != null) {
                Material = material;
            }

            if (color != null) {
                Color = color;
            }

            priceAmount = priceAmount ?? Price?.Amount;
            currency = currency ?? Price?.Currency;

            if (priceAmount is not null && currency is not null) {
                Price = new Price(priceAmount.Value, currency);
            }

            if (imageId is not null) {
                CategoryId = imageId.Value;
            }

            Validate();
        }
    }
}
