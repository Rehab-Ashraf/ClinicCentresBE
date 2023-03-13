using ClinicCentres.Core.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ClinicCentres.Data.EF
{
    public class ClinicCentresDbContext:DbContext
    {
        public ClinicCentresDbContext(DbContextOptions<ClinicCentresDbContext> options) :base(options)
        {

        }

        public DbSet<Category> Categories { get; private set; }
        public DbSet<Post> Posts { get; private set; }
        public DbSet<Branch> Branches { get; private set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfig())
                        .ApplyConfiguration(new PostConfig())
                        .ApplyConfiguration(new CommentConfig())
                        .ApplyConfiguration(new LikeConfig())
                        .ApplyConfiguration(new ProductConfig())
                        .ApplyConfiguration(new CaseConfig())
                        .ApplyConfiguration(new AppointmentConfig())
                        .ApplyConfiguration(new ImageConfig())
                        .ApplyConfiguration(new BranchConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
