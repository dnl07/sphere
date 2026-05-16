using Sphere.Domain.ClothingItems.Events;

namespace Sphere.Domain.ClothingItems {
    public partial class ClothingItem {
        public static ClothingItem Create(
            Guid categoryId,
            string? size,
            string? material,
            string? color,
            decimal? price,
            DateTime? boughtAt,
            string? store,
            string? brand,
            bool isArchived,
            string? notes,
            Guid imageId) {

            var item = new ClothingItem(categoryId, size, material, color, price, boughtAt, store, brand, isArchived, notes, imageId);

            item.Validate();

            item.AddDomainEvent(new ClothingItemCreatedEvent(item.Id));

            return item;
        }
    }
}
