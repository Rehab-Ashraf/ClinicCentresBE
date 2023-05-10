using ClinicCentres.Core.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Services.AppointmentService
{
    public interface IAppointmentService
    {
        Task<int> AddAppointment(Appointment appointment);
        Task<IList<Appointment>> GetAllAppointments();
        Task<Appointment> GetAppointmentById(int appointmentId);
        Task<int> BookAnAppointment(int caseId, int appointmentId);
        Task<int> UpdateAppointment(Appointment appointment);
        Task<bool> DeleteApointment(int appointmentId);
    }
}
