using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Repostories.AppointmentRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicCentres.Services.AppointmentService
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }
        public async Task<int> AddAppointment(Appointment appointment)
        {
            return await appointmentRepository.AddAppointment(appointment);
        }

        public async Task<IList<Appointment>> GetAllAppointments()
        {
            return await appointmentRepository.GetAllAppointments();
        }

        public async Task<int> BookAnAppointment(int caseId, int appointmentId)
        {
            return await appointmentRepository.BookAnAppointment(caseId,appointmentId);
        }

        public async Task<int> UpdateAppointment(Appointment appointment)
        {
            return await appointmentRepository.UpdateAppointment(appointment);
        }

        public async Task<bool> DeleteApointment(int appointmentId)
        {
            return await appointmentRepository.DeleteApointment(appointmentId);
        }

        public async Task<Appointment> GetAppointmentById(int appointmentId)
        {
            return await appointmentRepository.GetAppointmentById(appointmentId);
        }
    }
}
