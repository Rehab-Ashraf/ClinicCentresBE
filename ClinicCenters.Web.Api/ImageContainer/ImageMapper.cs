using AutoMapper;
using ClinicCentres.Core.DomainEntities.Entities;
using ClinicCentres.Models.Images;


namespace ClinicCentres.Web.Api.ImageContainer
{
    public class ImageMapper:Profile
    {
        public ImageMapper()
        {
            MapImage();
        }

        private void MapImage()
        {
            CreateMap<ImagesModel, Image>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ImageBytes, opt => opt.MapFrom(src => src.ImageBytes))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));
            CreateMap<Image, ImagesModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ImageBytes, opt => opt.MapFrom(src => src.ImageBytes))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));
        }
    }
}
