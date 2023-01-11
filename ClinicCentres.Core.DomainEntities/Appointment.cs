using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Core.DomainEntities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public DateTime Time { get; set; }
        public bool IsBooked { get; set; }
        public Case Case { get; set; }
        public int CaseId { get; set; }
    }
}
