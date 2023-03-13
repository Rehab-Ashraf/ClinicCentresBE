using ClinicCentres.Core.DomainEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ClinicCentres.Data.EF
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.ImageBytes).IsRequired();
            builder.HasOne(l => l.Post).WithMany(c => c.Images).HasForeignKey(c => c.PostId).IsRequired(false);
            builder.HasOne(l => l.Product).WithMany(c => c.Images).HasForeignKey(c => c.ProductId).IsRequired(false);
            builder.ToTable("Images");
        }
    }
}
