using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicCentres.Core.DomainEntities
{
    internal class LikeConfig : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).ValueGeneratedOnAdd();
            builder.HasOne(l=>l.Comment).WithMany(c=>c.Likes).HasForeignKey(c => c.CommentId).IsRequired(false);
            builder.HasOne(l => l.Post).WithMany(c => c.Likes).IsRequired(false);
        }
    }
}
