using Sphere.Domain.Common;

namespace Sphere.Domain.ClothingItems.Events {
    public class ClothingItemDeletedEvent : IDomainEvent {
        public Guid ClothingItemId { get; }
        public Guid ImageId { get; }
        public DateTime OccuredAt { get; }

        public ClothingItemDeletedEvent(Guid clothingItemId, Guid imageId) {
            ClothingItemId = clothingItemId;
            ImageId = imageId;
            OccuredAt = DateTime.UtcNow;
        }
    }
}
