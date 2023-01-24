using ClinicCentres.Core.DomainEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicCentres.Core.DomainEntities
{
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Description).IsRequired().HasMaxLength(100);
            builder.HasMany(c => c.Subcategories).WithOne().HasForeignKey(c => c.ParentId);
            builder.HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(c => c.CategoryId);
            builder.HasOne(a => a.Image)
            .WithOne(a => a.Category)
            .HasForeignKey<Image>(c => c.CategoryId);
        }
    }
}
