using Sphere.Domain.Common;

namespace Sphere.Domain.ClothingItems.Events {
    public class ClothingItemUpdatedEvent : IDomainEvent {
        public Guid ClothingItemId { get; }
        public DateTime OccurredAt { get; }

        public ClothingItemUpdatedEvent(Guid clothingItemId) {
            ClothingItemId = clothingItemId;
            OccurredAt = DateTime.UtcNow;
        }
    }
}
