using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Models.Appointments
{
    public class AppointmentInputModel
    {
        public int Id { get; set; }
        public DateTime DayTime { get; set; }
        public int? CaseId { get; set; }
    }
}
