using AutoMapper;
namespace ClinicCenters.Web.Api.Bootstrapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Initialize()
        {
            string[] Profiles =
            {
                "ClinicCentres.Core.DomainEntities",
                "ClinicCentres.Models",
                "ClinicCentres.Web.Api"
            };

            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(Profiles));
            return configuration;
        }
    }
}
