namespace Sphere.Domain.Clothing {
    public class ClothingItem {
        public string Name { get; set; }
        public string Type { get; set; }

        public ClothingItem(string name, string type) {
            Name = name; 
            Type = type;
        }
    }
}
