using ClinicCentres.Core.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ClinicCentres.Data.EF
{
    internal class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Description).IsRequired().HasMaxLength(10000);
            builder.Property(p => p.VideoURL).IsRequired(false);
            builder.HasMany(p => p.Comments).WithOne(c => c.Post).HasForeignKey(c => c.PostId);
            builder.HasOne(c => c.Category).WithMany(p => p.Posts).IsRequired(false);
            builder.HasOne(c => c.User).WithMany(p => p.Posts).IsRequired(true);
            builder.ToTable("Posts");
        }
    }
}
