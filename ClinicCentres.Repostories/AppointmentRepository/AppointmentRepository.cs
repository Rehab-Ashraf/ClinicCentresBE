using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicCentres.Repostories.AppointmentRepository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ClinicCentresDbContext clinicCentresDbContext;

        public AppointmentRepository(ClinicCentresDbContext clinicCentresDbContext)
        {
            this.clinicCentresDbContext = clinicCentresDbContext;
        }

        private int checkCaseExist(int? caseId)
        {
            var caseIsExist = clinicCentresDbContext.Cases.Where(x => x.Id == caseId).FirstOrDefault();
            if (caseIsExist == null)
                return -2;
            if (!caseIsExist.IsActive)
                return -1;

            return caseIsExist.Id;
        }
        public async Task<int> AddAppointment(Appointment appointment)
        {
            //check for the case first using case id if is not exist we will return not fount user if found and is deactive it will be it is deactive user please contact support or warning message it is a deactivated user
            if(appointment.CaseId > 0)
            {
                var caseIsExistId = checkCaseExist(appointment.CaseId);
                appointment.CaseId = caseIsExistId;
                appointment.IsBooked = true;
            }
            else
            {
                appointment.CaseId = null;
            }

            appointment.IsActive = true;
            await clinicCentresDbContext.Appointments.AddAsync(appointment);
            await clinicCentresDbContext.SaveChangesAsync();
            return appointment.Id;

        }

        
        public async Task<IList<Appointment>> GetAllAppointments()
        {
            //get all appointments that isn't active and in upcoming dates
            return await clinicCentresDbContext.Appointments
                .Where(a => a.IsActive == true && a.DayTime >= DateTime.Now)
                .Select(a => new Appointment(){ 
                    Id = a.Id,
                    CaseId = a.CaseId,
                    DayTime = a.DayTime,
                    IsBooked = a.IsBooked,
                    Case = a.Case
                }).ToListAsync();
        }
        public async Task<Appointment> GetAppointmentById(int appointmentId)
        {
            return await clinicCentresDbContext.Appointments.Where(a => a.Id == appointmentId).FirstOrDefaultAsync();
        }

        public async Task<int> BookAnAppointment(int caseId, int appointmentId)
        {
            //check if the appointment is exist and is not active
            var appointment = GetAppointmentById(appointmentId).Result;
            if (appointment == null)
                return -4;
            if (appointment.IsActive != true || appointment.DayTime <= DateTime.Now )
                return -3;

            //check if the case is exist and is not active
            var caseIsExistId = checkCaseExist(caseId);


            appointment.CaseId = caseIsExistId;
            appointment.IsBooked = true;
            clinicCentresDbContext.Update<Appointment>(appointment);
            await clinicCentresDbContext.SaveChangesAsync();
            return appointment.Id;
        }

        public async Task<int> UpdateAppointment(Appointment appointment)
        {
            var appointmentToUpdate = GetAppointmentById(appointment.Id).Result;
            if (appointmentToUpdate == null)
                return -4;
            if (appointmentToUpdate.IsActive || appointmentToUpdate.DayTime > DateTime.Now)
                return -3;

            if (appointment.CaseId > 0)
            {
                //check if the case is exist and is not active
                var caseIsExistId = checkCaseExist(appointment.CaseId);
                appointment.CaseId = caseIsExistId;
                appointment.IsBooked = true;
            }
            clinicCentresDbContext.Update<Appointment>(appointment);
            await clinicCentresDbContext.SaveChangesAsync();
            return appointment.Id;

        }

        public async Task<bool> DeleteApointment(int appointmentId)
        {
            var appointment = GetAppointmentById(appointmentId).Result;
            if (appointment == null)
                return false;
            appointment.IsActive = false;
            clinicCentresDbContext.Update<Appointment>(appointment);
            await clinicCentresDbContext.SaveChangesAsync();
            return true;
        }

        
    }
}
