using Microsoft.EntityFrameworkCore;
using Sphere.Domain.Categories;

namespace Sphere.Infrastructure.Persistance.Seeds {
    public static class CategorySeeder {
        public static void Seed(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Category>().HasData(
                // Tops
                Category.Create("T-Shirt"),
                Category.Create("Long Sleeve Shirt"),
                Category.Create("Blouse"),

                // Outerwear
                Category.Create("Jacket"),
                Category.Create("Coat"),
                Category.Create("Blazer"),

                // Bottoms
                Category.Create("Jeans"),
                Category.Create("Pants"),
                Category.Create("Shorts"),
                Category.Create("Leggings"),
                Category.Create("Joggers"),
                Category.Create("Sweatpants"),

                // Dresses and skirts
                Category.Create("Dress"),
                Category.Create("Skirt"),

                // Sweatshirts and hoodies
                Category.Create("Sweater"),
                Category.Create("Pullover"),
                Category.Create("Cardigan"),
                Category.Create("Hoodie"),

                // Accessories
                Category.Create("Hat"),
                Category.Create("Cap"),
                Category.Create("Scarf"),
                Category.Create("Gloves"),

                // Footwear
                Category.Create("Sneakers"),
                Category.Create("Boots"),
                Category.Create("High Heels")
            );
        }
    }
}
