using Sphere.Domain.ClothingItems.Events;
using Sphere.Domain.ClothingItems.ValueObjects;
using Sphere.Domain.Common;

namespace Sphere.Domain.ClothingItems {
    public partial class ClothingItem : AggregateRoot { 
        public string Name { get; private set; }

        public Guid CategoryId { get; private set; }

        public string? Description { get; private set; }
        public string? Size { get; private set; }
        public string? Material { get; private set; }
        public string? Color { get; private set; }
        public Price? Price { get; private set; }

        // TODO: Implement these properties in the commands and handlers
        public DateTime? BoughtAt { get; private set; }
        public string? Store { get; private set; }

        public Guid ImageId { get; private set; }

        #pragma warning disable CS8618
        private ClothingItem() { }
        #pragma warning restore CS8618

        private ClothingItem(string name, Guid categoryId, string? description, string? size, string? material, string? color, Price? price, Guid imageId) {
            Name = name;
            CategoryId = categoryId;
            Description = description;
            Size = size;
            Material = material;
            Color = color;
            Price = price;
            ImageId = imageId;
        }

        public void Delete() {
            AddDomainEvent(new ClothingItemDeletedEvent(Id, ImageId));
        }
    }
}
