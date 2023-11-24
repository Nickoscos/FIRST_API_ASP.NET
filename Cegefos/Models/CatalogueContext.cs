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
            modelBuilder.Entity<Machine>().HasOne(s => s.Salle);
            modelBuilder.Entity<Cours>().HasOne(c => c.Formation);
            modelBuilder.Seed();
        }

        public DbSet<Formation> Formations { get; set; }
        public DbSet<Salle> Salles { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Cours> Courss { get; set; }


    }
}
