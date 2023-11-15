using Microsoft.EntityFrameworkCore;

namespace Cegefos.API.Models
{
    public class CatalogueContext : DbContext
    {
        public CatalogueContext(DbContextOptions<CatalogueContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Salle>().HasMany(s => s.Formations).WithOne(a => a.Salle).HasForeignKey(a => a.SalleId);
            modelBuilder.Entity<Formation>().HasOne(f => f.Salle);
            modelBuilder.Seed();
        }

        public DbSet<Formation> Formations { get; set; }
        public DbSet<Salle> Salles { get; set; }
        /*        public DbSet<Machine> Machines { get; set; }
                */

    }
}
