using Microsoft.EntityFrameworkCore;

namespace Cegefos.API.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Salle>().HasData(
                new Salle { Id=1, Libelle="Salle 1", Nombre_De_Places=10 });

            modelBuilder.Entity<Machine>().HasData(
                new Machine { Id = 1, SalleId = 1, Libelle = "Machine 1", Processeur = "Processeur 1", Capacite = "Capacite 1", Memoire = "Memoire 1", Taille_ecran = 10,  });
        }
    }
}
