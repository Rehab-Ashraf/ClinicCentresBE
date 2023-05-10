using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Models.Appointments
{
    public class AppointmentBasicModel
    {
        public int Id { get; set; }
        public DateTime DayTime { get; set; }
        public DateTime Time { get; set; }
        public bool IsBooked { get; set; }
    }
}
