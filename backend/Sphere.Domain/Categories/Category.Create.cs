namespace Sphere.Domain.Categories {
    public partial class Category{
        public static Category Create(string name, Guid id) {
            var category = new Category(name) { Id = id};
            return category;
        }
    }
}
