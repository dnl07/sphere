using Sphere.Domain.Common;

namespace Sphere.Domain.ClothingItems.Events {
    public class ClothingItemDeletedEvent : IDomainEvent {
        public Guid ClothingItemId { get; }
        public Guid ImageId { get; }
        public DateTime OccurredAt { get; }

        public ClothingItemDeletedEvent(Guid clothingItemId, Guid imageId) {
            ClothingItemId = clothingItemId;
            ImageId = imageId;
            OccurredAt = DateTime.UtcNow;
        }
    }
}
