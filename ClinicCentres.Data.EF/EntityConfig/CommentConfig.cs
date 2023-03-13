using ClinicCentres.Core.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ClinicCentres.Data.EF
{
    internal class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Description).IsRequired().HasMaxLength(1000);
            builder.Property(c => c.DateTime).IsRequired();
            builder.HasMany(c => c.Replies).WithOne().HasForeignKey(c => c.ParentId);
            builder.ToTable("Comments");
        }
    }
}
