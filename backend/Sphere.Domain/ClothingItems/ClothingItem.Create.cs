using Sphere.Domain.ClothingItems.Events;
using Sphere.Domain.ClothingItems.ValueObjects;

namespace Sphere.Domain.ClothingItems {
    public partial class ClothingItem {
        public static ClothingItem Create(
            string name,
            Guid categoryId,
            string? size,
            string? material,
            string? color,
            decimal? priceAmount,
            string? currency,
            DateTime? boughtAt,
            string? store,
            string? brand,
            bool isArchived,
            string? notes,
            Guid imageId) {

            Price? price = null;

            if (priceAmount.HasValue) {
                price = new Price(priceAmount.Value, currency ?? "EUR");
            }

            var item = new ClothingItem(name, categoryId, size, material, color, price, boughtAt, store, brand, isArchived, notes, imageId);

            item.Validate();

            item.AddDomainEvent(new ClothingItemCreatedEvent(item.Id));

            return item;
        }
    }
}
