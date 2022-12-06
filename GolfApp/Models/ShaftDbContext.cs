using Microsoft.EntityFrameworkCore;

namespace GolfApp.Models
{
    public class ShaftDbContext : DbContext
    {
        public ShaftDbContext(DbContextOptions<ShaftDbContext> options) : base(options)
        {

        }

        public DbSet<Shaft> shaft { get; set; }
        public DbSet<Brand> brand { get; set; }
        public DbSet<AdapterSettings> adapterSettings { get; set; }
        public DbSet<BuildType> buildType { get; set; }
        public DbSet<GripModel> gripModel { get; set; }
        public DbSet<ModelFlex> modelFlex { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shaft>().Ignore(o => o.shaftImage);
        }
    }

}
