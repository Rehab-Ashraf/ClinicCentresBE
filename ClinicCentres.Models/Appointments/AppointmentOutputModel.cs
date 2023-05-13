using ClinicCentres.Core.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Models.Appointments
{
    public class AppointmentOutputModel
    {
        public DateTime Day { get; set; }
        public int Id { get; set; }
        public int? CaseId { get; set; }
        public Case Case { get; set; }
        public bool IsBooked { get; set; }
    }
}
