using Sphere.Domain.Clothing.ValueObjects;
using Sphere.Domain.ClothingItems.Events;

namespace Sphere.Domain.ClothingItems {
    public partial class ClothingItem {
        public ClothingItem Create(
            string name,
            Guid categoryId,
            string? description,
            string? size,
            string? material,
            string? color,
            decimal? priceAmount,
            string? currency,
            Guid imageId) {

            Price? price = null;

            if (priceAmount.HasValue) {
                price = new Price(priceAmount.Value, currency ?? "EUR");
            }

            var item = new ClothingItem(name, categoryId, description, size, material, color, price, imageId);

            Validate();

            AddDomainEvent(new ClothingItemCreatedEvent(Id));

            return item;
        }
    }
}
