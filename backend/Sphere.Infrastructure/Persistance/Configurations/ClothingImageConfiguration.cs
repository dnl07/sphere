using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sphere.Domain.ClothingImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Infrastructure.Persistance.Configurations {
    public  class ClothingImageConfiguration : IEntityTypeConfiguration<ClothingImage> {
        public void Configure(EntityTypeBuilder<ClothingImage> builder) {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FileName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.FileSize)
                .IsRequired();

            builder.Property(x => x.ContentType)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.ClothingItemId)
                .IsRequired();

            builder.ToTable("ClothingImages");
        }
    }
}
