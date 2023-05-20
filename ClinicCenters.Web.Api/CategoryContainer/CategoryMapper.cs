using AutoMapper;
using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Models;

namespace ClinicCentres.Web.Api.CategoryContainer
{
    public class CategoryMapper:Profile
    {
        public CategoryMapper()
        {

            MapCategory();
        }

        private void MapCategory()
        {
            CreateMap<CategoryModel, Category>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<Category, CategoryModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
