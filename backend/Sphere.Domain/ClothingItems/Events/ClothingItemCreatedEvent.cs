using Sphere.Domain.Common;

namespace Sphere.Domain.ClothingItems.Events {
    public class ClothingItemCreatedEvent : IDomainEvent {
        public Guid ClothingItemId { get; }
        public string Name { get; }
        public DateTime OccuredAt { get; }

        public ClothingItemCreatedEvent(Guid clothingItemId, string name) {
            ClothingItemId = clothingItemId;
            Name = name;
            OccuredAt = DateTime.UtcNow;
        }
    }
}
