using Microsoft.EntityFrameworkCore;
using Sphere.Domain.Clothing;

namespace Sphere.Infrastructure.Persistance {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
       
        public DbSet<ClothingItem> ClothingItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
