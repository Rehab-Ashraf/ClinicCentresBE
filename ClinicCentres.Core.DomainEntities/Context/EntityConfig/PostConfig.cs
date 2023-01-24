using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicCentres.Core.DomainEntities
{
    internal class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Description).IsRequired().HasMaxLength(10000);
            builder.HasMany(p => p.Comments).WithOne(c => c.Post).HasForeignKey(c => c.PostId);
            builder.HasOne(c => c.Category).WithMany(p => p.Posts).IsRequired();
        }
    }
}
