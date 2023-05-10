using AutoMapper;
using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Models;
using ClinicCentres.Models.Appointments;
using ClinicCentres.Services.AppointmentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicCentres.Web.Api.AppointmentContainer
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAppointmentService appointmentService;

        public AppointmentController(IMapper mapper, IAppointmentService appointmentService)
        {
            this.mapper = mapper;
            this.appointmentService = appointmentService;
        }

        [Authorize(Policy = "AddAppointment")]
        [HttpPost]
        public async Task<IActionResult> Appointment(AppointmentInputModel appointmentInputModel)
        {
            if(appointmentInputModel.DayTime < DateTime.Now)
                return BadRequest(ResponseResult.Failed(ErrorCode.Error, $"The Day and Time should be in future"));

            var appointment = mapper.Map<Appointment>(appointmentInputModel);
            var result = await appointmentService.AddAppointment(appointment);

            if(result == -2)
                return BadRequest(ResponseResult.Failed(ErrorCode.Error, $"There is no case exist with this {appointmentInputModel.CaseId} Id"));
            if(result == -1)
                return BadRequest(ResponseResult.Failed(ErrorCode.Error, $"This case is decative"));
            return Ok(ResponseResult.SucceededWithData(result));

        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Appointment()
        {
            var appointments = await appointmentService.GetAllAppointments();
            var result = mapper.Map<IList<AppointmentOutputModel>>(appointments);
            return Ok(ResponseResult.SucceededWithData(result));
        }

        [Authorize(Policy = "UpdateAppointment")]
        [HttpGet]
        [Route("GetAppointmentById")]
        public async Task<IActionResult> Appointment(int id)
        {
            var appointment = await appointmentService.GetAppointmentById(id);
            var result = mapper.Map<AppointmentOutputModel>(appointment);
            return Ok(ResponseResult.SucceededWithData(result));
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("BookAnAppointment")]
        public async Task<IActionResult> BookAnAppointment(int caseId, int appointmentId)
        {
            var result = await appointmentService.BookAnAppointment(caseId, appointmentId);

            if (result == -4)
                return BadRequest(ResponseResult.Failed(ErrorCode.Error, $"There is no appointment exist with this {appointmentId} Id"));
            if (result == -3)
                return BadRequest(ResponseResult.Failed(ErrorCode.Error, $"This appointment is decative"));
            if (result == -2)
                return BadRequest(ResponseResult.Failed(ErrorCode.Error, $"There is no case exist with this {caseId} Id"));
            if (result == -1)
                return BadRequest(ResponseResult.Failed(ErrorCode.Error, $"This case is decative"));
            return Ok(ResponseResult.SucceededWithData(result));
        }

        [Authorize(Policy = "UpdateAppointment")]
        [HttpPut]
        public async Task<IActionResult> UpdateAppointment(AppointmentInputModel appointmentInputModel)
        {
            if (appointmentInputModel.DayTime < DateTime.Now)
                return BadRequest(ResponseResult.Failed(ErrorCode.Error, $"The Day and Time should be in future"));

            var appointment = mapper.Map<Appointment>(appointmentInputModel);
            var result = await appointmentService.UpdateAppointment(appointment);


            if (result == -4)
                return BadRequest(ResponseResult.Failed(ErrorCode.Error, $"There is no appointment exist with this {appointment.Id} Id"));
            if (result == -3)
                return BadRequest(ResponseResult.Failed(ErrorCode.Error, $"This appointment is decative"));
            if (result == -2)
                return BadRequest(ResponseResult.Failed(ErrorCode.Error, $"There is no case exist with this {appointment.CaseId} Id"));
            if (result == -1)
                return BadRequest(ResponseResult.Failed(ErrorCode.Error, $"This case is decative"));
            return Ok(ResponseResult.SucceededWithData(result));
        }

        [Authorize(Policy = "DeleteAppointment")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var result = await appointmentService.DeleteApointment(id);
            if (!result)
                return BadRequest(ResponseResult.Failed(ErrorCode.Error, $"There is no appointment with {id} id"));
            return Ok(ResponseResult.SucceededWithData(result));
        }
    }
}
