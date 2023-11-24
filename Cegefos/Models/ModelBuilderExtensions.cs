using Microsoft.EntityFrameworkCore;

namespace Cegefos.API.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Salle>().HasData(
                new Salle { Id = 1, Libelle = "Salle 1", Nombre_De_Places = 10},
                new Salle { Id = 2, Libelle = "Salle 2", Nombre_De_Places = 10 });
            modelBuilder.Entity<Formation>().HasData(
                new Formation { Id = 1, Libelle = "Formation 1", SalleId = 1 },
                new Formation { Id = 2, Libelle = "Formation 2", SalleId = 2 });
            modelBuilder.Entity<Machine>().HasData(
                new Machine { Id = 1, Libelle = "Machine 1", Processeur = "Processeur 1", Capacite = "Capacite 1", Memoire = "Memoire 1", Taille_ecran = 10, SalleId=1 });
            modelBuilder.Entity<Cours>().HasData(
                new Cours { Id = 1, Code = "Code 1", Titre = "Titre 1", Duree = 1, Programme = "Programme 1", FormationId = 1, SalleId = 1 });
        }
    }
}
