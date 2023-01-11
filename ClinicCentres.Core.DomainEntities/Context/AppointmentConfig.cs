using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Core.DomainEntities.Context
{
    internal class AppointmentConfig : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Day).IsRequired();
            builder.Property(a => a.Time).IsRequired();
            builder.HasOne(a => a.Case).WithMany(c=>c.Appointments)
                    .HasForeignKey(a=>a.CaseId);
        }
    }
}
