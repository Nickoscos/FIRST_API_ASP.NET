using Microsoft.EntityFrameworkCore;


namespace Cegefos.API.Models
{
    public class CatalogueContext : DbContext
    {
        public CatalogueContext(DbContextOptions<CatalogueContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Formation>().HasOne(f => f.Salle);
            modelBuilder.Entity<Machine>().HasOne(s => s.Salle).WithMany(s => s.Machines).HasForeignKey(m => m.SalleId);
            modelBuilder.Entity<Salle>().HasMany(s => s.Machines).WithOne(mi => mi.Salle).HasForeignKey(si => si.SalleId);
            modelBuilder.Entity<Cours>().HasOne(c => c.Formation);
            modelBuilder.Seed();
        }

        public DbSet<Formation> Formations { get; set; }
        public DbSet<Salle> Salles { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Cours> Courss { get; set; }


    }
}
