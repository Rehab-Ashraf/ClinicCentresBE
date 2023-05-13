using ClinicCentres.Core.DomainEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicCentres.Repostories.AppointmentRepository
{
    public interface IAppointmentRepository
    {
        Task<int> AddAppointment(Appointment appointment);
        Task<IList<Appointment>> GetAllAppointments();
        Task<Appointment> GetAppointmentById(int appointmentId);
        Task<int> BookAnAppointment(int caseId, int appointmentId);
        Task<int> UpdateAppointment(Appointment appointment);
        Task<bool> DeleteApointment(int appointmentId);
    }
}
