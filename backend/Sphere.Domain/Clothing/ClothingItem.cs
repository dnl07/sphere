using Sphere.Domain.Common;

namespace Sphere.Domain.Clothing {
    public class ClothingItem : AggregateRoot {
        public string Name { get; set; }
        public string Type { get; set; }

        private ClothingItem() { }

        public ClothingItem(string name, string type) {
            Name = name; 
            Type = type;
        }
    }
}
