using Sphere.Domain.Common;

namespace Sphere.Domain.Categories {
    public partial class Category : Entity {
        public string Name { get; set; }

        #pragma warning disable CS8618
        private Category() { }
        #pragma warning restore CS8618

        private Category(string name) {
            Name = name;
        }
    }
}
