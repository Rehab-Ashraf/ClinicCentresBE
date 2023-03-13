using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Core.DomainEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicCentres.Data.EF
{
    internal class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Description).IsRequired().HasMaxLength(10000);
            builder.Property(b => b.IsActive).IsRequired();
            builder.ToTable("Branches");
        }
    }
}
