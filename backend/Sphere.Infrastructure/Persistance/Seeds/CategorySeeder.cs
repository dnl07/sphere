using Microsoft.EntityFrameworkCore;
using Sphere.Domain.Categories;

namespace Sphere.Infrastructure.Persistance.Seeds {
    public static class CategorySeeder {
        public static void Seed(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Category>().HasData(
                // Tops
                Category.Create("T-Shirt", GuidHelper.FromString("T-Shirt")),
                Category.Create("Long Sleeve Shirt", GuidHelper.FromString("Long Sleeve Shirt")),
                Category.Create("Blouse", GuidHelper.FromString("Blouse")),

                // Outerwear
                Category.Create("Jacket", GuidHelper.FromString("Jacket")),
                Category.Create("Coat", GuidHelper.FromString("Coat")),
                Category.Create("Blazer", GuidHelper.FromString("Blazer")),

                // Bottoms
                Category.Create("Jeans", GuidHelper.FromString("Jeans")),
                Category.Create("Pants", GuidHelper.FromString("Pants")),
                Category.Create("Shorts", GuidHelper.FromString("Shorts")),
                Category.Create("Leggings", GuidHelper.FromString("Leggings")),
                Category.Create("Joggers", GuidHelper.FromString("Joggers")),
                Category.Create("Sweatpants", GuidHelper.FromString("Sweatpants")),

                // Dresses and skirts 
                Category.Create("Dress", GuidHelper.FromString("Dress")),
                Category.Create("Skirt", GuidHelper.FromString("Skirt")),

                // Sweatshirts and hoodies
                Category.Create("Sweater", GuidHelper.FromString("Sweater")),
                Category.Create("Pullover", GuidHelper.FromString("Pullover")),
                Category.Create("Cardigan", GuidHelper.FromString("Cardigan")),
                Category.Create("Hoodie", GuidHelper.FromString("Hoodie")),

                // Accessories
                Category.Create("Hat", GuidHelper.FromString("Hat")),
                Category.Create("Cap", GuidHelper.FromString("Cap")),
                Category.Create("Scarf", GuidHelper.FromString("Scarf")),
                Category.Create("Gloves", GuidHelper.FromString("Gloves")),

                // Footwear
                Category.Create("Sneakers", GuidHelper.FromString("Sneakers")),
                Category.Create("Boots", GuidHelper.FromString("Boots")),
                Category.Create("High Heels", GuidHelper.FromString("High Heels"))
            );
        }
    }
}
