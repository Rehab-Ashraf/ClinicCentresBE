using ClinicCentres.Core.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ClinicCentres.Data.EF
{
    internal class LikeConfig : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).ValueGeneratedOnAdd();
            builder.HasOne(l=>l.Comment).WithMany(c=>c.Likes).HasForeignKey(c => c.CommentId).IsRequired(false);
            builder.HasOne(l => l.Post).WithMany(c => c.Likes).IsRequired(false);
            builder.ToTable("Likes");
        }
    }
}
