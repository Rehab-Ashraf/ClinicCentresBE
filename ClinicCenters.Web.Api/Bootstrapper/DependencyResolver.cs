using Autofac;
using AutoMapper;
using ClinicCentres.Data.EF;
using ClinicCentres.Repostories.BranchRepostory;
using ClinicCentres.Services.BranchService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ClinicCenters.Web.Api.Bootstrapper
{
    public class DependencyResolver : Module
    {
        private readonly IWebHostEnvironment _env;
        public IConfiguration Configuration { get; set; }
        public DependencyResolver(IWebHostEnvironment env)
        {
            _env = env;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{_env.EnvironmentName}.json", optional: true);

            Configuration = configBuilder.Build();
            LoadModules(builder);
        }

        private void LoadModules(ContainerBuilder builder)
        {
            LoadMappers(builder);
            LoadDbContexts(builder);
            LoadBranches(builder);
        }
        private void LoadMappers(ContainerBuilder builder)
        {
            var mapperConfig = AutoMapperConfig.Initialize();

            builder.Register(c => AutoMapperConfig.Initialize()).AsSelf().SingleInstance();
            builder.Register(context => context.Resolve<MapperConfiguration>()
            .CreateMapper(context.Resolve))
            .As<IMapper>()
            .InstancePerLifetimeScope();

        }
        private void LoadDbContexts(ContainerBuilder builder)
        {
            builder.RegisterType<ClinicCentresDbContext>().InstancePerLifetimeScope();
        }
        private void LoadBranches(ContainerBuilder builder)
        {
            //register service
            builder.RegisterType<BranchService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            //register repository
            builder.RegisterType<BranchRepostory>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
