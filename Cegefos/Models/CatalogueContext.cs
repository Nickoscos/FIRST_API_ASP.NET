using Microsoft.EntityFrameworkCore;

namespace Cegefos.API.Models
{
    public class CatalogueContext : DbContext
    {
        public CatalogueContext(DbContextOptions<CatalogueContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Salle>().HasMany(s => s.Machines).WithOne(a => a.Salle).HasForeignKey(a => a.SalleId);

            modelBuilder.Seed();
        }

        public DbSet<Machine> Machines { get; set; }
        public DbSet<Salle> Salles { get; set; }

    }
}
