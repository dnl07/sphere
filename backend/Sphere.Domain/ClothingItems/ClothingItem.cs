using Sphere.Domain.Clothing.ValueObjects;
using Sphere.Domain.ClothingItems.Events;
using Sphere.Domain.Common;
using Sphere.Domain.Images;

namespace Sphere.Domain.Clothing {
    public class ClothingItem : AggregateRoot {
        public string Name { get; set; }
        public string Category { get; set; }
        public string? Description { get; set; }
        public string? Size { get; set; }
        public string? Material { get; set; }
        public string? Color { get; set; }
        public Price? Price { get; set; }

        // Where bought?
        // When bought?

        public Guid ImageId { get; set; }
        public Image Image { get; set; }

        #pragma warning disable CS8618
        private ClothingItem() { }
        #pragma warning restore CS8618

        public ClothingItem(string name, string category, string? description, string? size, string? material, string? color, Price? price, Image image) {
            Name = name; 
            Category = category;
            Description = description;
            Size = size;
            Material = material;
            Color = color;
            Price = price;
            Image = image;

            AddDomainEvent(new ClothingItemCreatedEvent(Id, Name));
        }

        public void Delete() {
            AddDomainEvent(new ClothingItemDeletedEvent(Id, Image.Id));
        }
    }
}
