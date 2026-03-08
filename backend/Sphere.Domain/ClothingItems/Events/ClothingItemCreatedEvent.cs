using Sphere.Domain.Common;

namespace Sphere.Domain.ClothingItems.Events {
    public class ClothingItemCreatedEvent : IDomainEvent {
        public Guid ClothingItemId { get; }
        public DateTime OccuredAt { get; }

        public ClothingItemCreatedEvent(Guid clothingItemId) {
            ClothingItemId = clothingItemId;
            OccuredAt = DateTime.UtcNow;
        }
    }
}
