using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sphere.Domain.Clothing;
using Sphere.Domain.ClothingImages;

namespace Sphere.Infrastructure.Persistance.Configurations {
    public class ClothingItemConfiguration : IEntityTypeConfiguration<ClothingItem> {
        public void Configure(EntityTypeBuilder<ClothingItem> builder) {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

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
                .WithOne()
                .HasForeignKey<ClothingImage>("ClothingItemId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("ClothingItems");
        }
    }
}
