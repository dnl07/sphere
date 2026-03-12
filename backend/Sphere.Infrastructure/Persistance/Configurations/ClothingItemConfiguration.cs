using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sphere.Domain.ClothingItems;

namespace Sphere.Infrastructure.Persistance.Configurations {
    public class ClothingItemConfiguration : IEntityTypeConfiguration<ClothingItem> {
        public void Configure(EntityTypeBuilder<ClothingItem> builder) {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.OwnsOne(x => x.Price, price => {
                price.Property(p => p.Amount)
                    .HasColumnName("PriceAmount")
                    .HasColumnType("decimal(10,2)")
                    .IsRequired();

                price.Property(p => p.Currency)
                    .HasColumnName("PriceCurrency")
                    .HasMaxLength(3)
                    .IsRequired();
            });

            builder.HasOne(x => x.Image)
                .WithMany()
                .HasForeignKey(x => x.ImageId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("ClothingItems");
        }
    }
}
