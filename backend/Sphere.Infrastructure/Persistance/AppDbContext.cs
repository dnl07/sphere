using Microsoft.EntityFrameworkCore;
using Sphere.Domain.Clothing;
using Sphere.Domain.ClothingImages;

namespace Sphere.Infrastructure.Persistance {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
       
        public DbSet<ClothingItem> ClothingItems { get; set; }
        public DbSet<ClothingImage> ClothingImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
