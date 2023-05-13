using AutoMapper;
using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Models.Appointments;

namespace ClinicCentres.Web.Api.AppointmentContainer
{
    public class AppointmentMapper:Profile
    {
        public AppointmentMapper()
        {
            MapAppointmentBasicDetails();
            MappAppointmentInputModel();
            MappAppointmentOutputModel();
        }
        private void MapAppointmentBasicDetails()
        {
            CreateMap<AppointmentBasicModel, Appointment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DayTime, opt => opt.MapFrom(src => src.DayTime))
                .ForMember(dest => dest.IsBooked, opt => opt.MapFrom(src => src.IsBooked));
            CreateMap<Appointment, AppointmentBasicModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DayTime, opt => opt.MapFrom(src => src.DayTime))
                .ForMember(dest => dest.IsBooked, opt => opt.MapFrom(src => src.IsBooked));
        }

        private void MappAppointmentInputModel()
        {
            CreateMap<AppointmentInputModel, Appointment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DayTime, opt => opt.MapFrom(src => src.DayTime))
                .ForMember(dest => dest.CaseId, opt => opt.MapFrom(src=>src.CaseId));
            CreateMap<Appointment, AppointmentInputModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DayTime, opt => opt.MapFrom(src => src.DayTime))
                .ForMember(dest => dest.CaseId, opt => opt.MapFrom(src => src.CaseId));
        }
        private void MappAppointmentOutputModel()
        {
            CreateMap<AppointmentOutputModel, Appointment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DayTime, opt => opt.MapFrom(src => src.Day))
                .ForMember(dest => dest.CaseId, opt => opt.MapFrom(src => src.CaseId))
                .ForMember(dest=>dest.Case, opt=>opt.MapFrom(src => src.Case))
                .ForMember(dest=>dest.IsBooked, opt=>opt.MapFrom(src=>src.IsBooked));
            CreateMap<Appointment, AppointmentOutputModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Day, opt => opt.MapFrom(src => src.DayTime))
                .ForMember(dest => dest.CaseId, opt => opt.MapFrom(src => src.CaseId))
                .ForMember(dest => dest.Case, opt => opt.MapFrom(src => src.Case))
                .ForMember(dest => dest.IsBooked, opt => opt.MapFrom(src => src.IsBooked));
        }
    }
}
