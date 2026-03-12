using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sphere.Domain.MediaFiles;

namespace Sphere.Infrastructure.Persistance.Configurations {
    public  class MediaFileConfiguration : IEntityTypeConfiguration<MediaFile> {
        public void Configure(EntityTypeBuilder<MediaFile> builder) {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FileName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.FileSize)
                .IsRequired();

            builder.Property(x => x.ContentType)
                .IsRequired()
                .HasMaxLength(100);

            builder.ToTable("MediaFiles");
        }
    }
}
