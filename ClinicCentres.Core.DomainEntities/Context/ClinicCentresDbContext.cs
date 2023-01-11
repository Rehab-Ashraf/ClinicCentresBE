using ClinicCentres.Core.DomainEntities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ClinicCentres.Core.DomainEntities
{
    public class ClinicCentresDbContext:DbContext
    {
        public IConfiguration Configuration { get; set; }

        public ClinicCentresDbContext(DbContextOptions<ClinicCentresDbContext> options) :base(options)
        {

        }

        public DbSet<Category> Category { get; private set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfig())
                        .ApplyConfiguration(new PostConfig())
                        .ApplyConfiguration(new CommentConfig())
                        .ApplyConfiguration(new LikeConfig())
                        .ApplyConfiguration(new ProductConfig())
                        .ApplyConfiguration(new CaseConfig())
                        .ApplyConfiguration(new AppointmentConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
