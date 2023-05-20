using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Core.DomainEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicCentres.Data.EF
{
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Description).IsRequired().HasMaxLength(100);
            builder.Property(c => c.IsActive).IsRequired();
            builder.HasMany(c => c.Subcategories).WithOne().HasForeignKey(c => c.ParentId).IsRequired(false);
            builder.HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(c => c.CategoryId).IsRequired(false); ;
            builder.HasOne(a => a.Image)
            .WithOne(a => a.Category)
            .HasForeignKey<Image>(c => c.CategoryId).IsRequired(false); ;
        }
    }
}
