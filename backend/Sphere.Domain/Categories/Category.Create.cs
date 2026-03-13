using Sphere.Domain.Common;

namespace Sphere.Domain.Categories {
    public partial class Category{
        public Category Create(string name) {
            var category = new Category(name);
            return category;
        }
    }
}
