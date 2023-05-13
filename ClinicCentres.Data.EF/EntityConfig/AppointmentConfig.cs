using ClinicCentres.Core.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ClinicCentres.Data.EF
{
    internal class AppointmentConfig : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.DayTime).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
            builder.HasOne(a => a.Case).WithMany(c=>c.Appointments)
                    .HasForeignKey(a=>a.CaseId).IsRequired(false);
            builder.ToTable("Appointments");
        }
    }
}
