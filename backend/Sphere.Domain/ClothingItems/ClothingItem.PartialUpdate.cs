using Sphere.Domain.Categories;
using Sphere.Domain.Clothing.ValueObjects;
using Sphere.Domain.MediaFiles;

namespace Sphere.Domain.ClothingItems {
    public partial class ClothingItem {
        public void Update(
            string? name = null,
            Category? category = null,
            string? description = null,
            string? size = null,
            string? material = null,
            string? color = null,
            decimal? priceAmount = null,
            string? currency = null,
            MediaFile? newImage = null) {
            if (name != null) {
                Name = name;
            }

            if (category != null) {
                Category = category;
                CategoryId = category.Id;
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

            if (newImage != null) {
                Image = newImage;
                ImageId = newImage.Id;
            }

            Validate();
        }
    }
}
