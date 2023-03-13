

using ClinicCentres.Core.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicCentres.Data.EF
{
    internal class CaseConfig : IEntityTypeConfiguration<Case>
    {
        public void Configure(EntityTypeBuilder<Case> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(100);
            builder.Property(c => c.DateOfBirth).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(100);
            builder.ToTable("Cases");
        }
    }
}
