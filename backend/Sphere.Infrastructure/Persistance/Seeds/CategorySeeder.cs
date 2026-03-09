using Microsoft.EntityFrameworkCore;
using Sphere.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Infrastructure.Persistance.Seeds {
    public static class CategorySeeder {
        public static void Seed(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Category>().HasData(
                new Category("Shirts") { Id = Guid.Parse("11111111-1111-1111-1111-111111111111") },
                new Category("Pants") { Id = Guid.Parse("22222222-2222-2222-2222-222222222222") },
                new Category("Shoes") { Id = Guid.Parse("33333333-3333-3333-3333-333333333333") }
            );
        }
    }
}
