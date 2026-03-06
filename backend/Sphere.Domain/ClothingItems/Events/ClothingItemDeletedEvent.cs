using Sphere.Domain.Common;

namespace Sphere.Domain.ClothingItems.Events {
    public class ClothingItemDeletedEvent : IDomainEvent {
        public Guid ClothingItemId { get; }
        public Guid ImageId { get; }
        public string Name { get; }
        public DateTime OccuredAt { get; }

        public ClothingItemDeletedEvent(Guid clothingItemId, Guid imageId, string name) {
            ClothingItemId = clothingItemId;
            ImageId = imageId;
            Name = name;
            OccuredAt = DateTime.UtcNow;
        }
    }
}
