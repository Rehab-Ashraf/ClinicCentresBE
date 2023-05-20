using Autofac;
using AutoMapper;
using ClinicCentres.Data.EF;
using ClinicCentres.Repostories.AppointmentRepository;
using ClinicCentres.Repostories.BranchRepository;
using ClinicCentres.Repostories.CaseRepository;
using ClinicCentres.Repostories.CategoryRepository;
using ClinicCentres.Repostories.UserRepository;
using ClinicCentres.Services.AppointmentService;
using ClinicCentres.Services.BranchService;
using ClinicCentres.Services.CaseService;
using ClinicCentres.Services.CategoryService;
using ClinicCentres.Services.UserService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ClinicCenters.Web.Api.Bootstrapper
{
    public class DependencyResolver : Module, IDesignTimeDbContextFactory<ClinicCentresDbContext>
    {
        public DependencyResolver()
        {

        }
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
            LoadAppointments(builder);
            LoadCases(builder);
            LoadUseres(builder);
            LoadCategories(builder);
        }
        public ClinicCentresDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var connectionString = configuration.GetConnectionString("ClinicCentresDbConnection");

            var builder = new DbContextOptionsBuilder<ClinicCentresDbContext>();

            builder.UseSqlServer(connectionString);

            return new ClinicCentresDbContext(builder.Options);
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
            builder.RegisterType<BranchService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            //register repository
            builder.RegisterType<BranchRepository>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }

        private void LoadAppointments(ContainerBuilder builder)
        {
            builder.RegisterType<AppointmentService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<AppointmentRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }
        private void LoadCases(ContainerBuilder builder)
        {
            builder.RegisterType<CasesService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<CasesRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }
        private void LoadUseres(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }

        private void LoadCategories(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
