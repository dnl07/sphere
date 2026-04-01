using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sphere.Domain.ClothingItems;

namespace Sphere.Infrastructure.Persistance.Configurations {
    public class ClothingItemConfiguration : IEntityTypeConfiguration<ClothingItem> {
        public void Configure(EntityTypeBuilder<ClothingItem> builder) {

            builder.ToTable("ClothingItems");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Size)
                .HasMaxLength(50);

            builder.Property(x => x.Material)
                .HasMaxLength(100);

            builder.Property(x => x.Color)
                .HasMaxLength(50);

            builder.Property(x => x.BoughtAt);

            builder.Property(x => x.Store)
                .HasMaxLength(150);

            builder.Property(x => x.Brand)
                .HasMaxLength(150);

            builder.Property(x => x.IsArchived);

            builder.Property(x => x.Notes)
                .HasMaxLength(500);

            builder.Property(x => x.CategoryId)
                .IsRequired();

            builder.Property(x => x.ImageId)
                .IsRequired();

            builder.OwnsOne(x => x.Price, price => {
                price.Property(p => p.Amount)
                    .HasColumnName("PriceAmount")
                    .HasColumnType("decimal(10,2)");

                price.Property(p => p.Currency)
                    .HasColumnName("PriceCurrency")
                    .HasMaxLength(3);
            });
        }
    }
}
