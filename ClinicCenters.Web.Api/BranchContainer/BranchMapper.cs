using AutoMapper;
using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Models.Branches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicCentres.Web.Api.BranchContainer
{
    public class BranchMapper : Profile
    {
        public BranchMapper()
        {

            MapBranch();
        }

        private void MapBranch()
        {
            CreateMap<BranchModel, Branch>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<Branch, BranchModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
