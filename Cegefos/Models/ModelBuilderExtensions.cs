using Microsoft.EntityFrameworkCore;

namespace Cegefos.API.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Salle>().HasData(
                new Salle { Id = 1, Libelle = "Salle 1", Nombre_De_Places = 10 },
                new Salle { Id = 2, Libelle = "Salle 2", Nombre_De_Places = 12 });
            modelBuilder.Entity<Formation>().HasData(
                new Formation { Id = 1, Libelle = "Formation 1", SalleId = 1, CoursId = 1 },
                new Formation { Id = 2, Libelle = "Formation 2", SalleId = 2, CoursId = 2 },
                new Formation { Id = 3, Libelle = "Formation 3", SalleId = 2, CoursId = 3 },
                new Formation { Id = 4, Libelle = "Formation 4", SalleId = 1, CoursId = 4 },
                new Formation { Id = 5, Libelle = "Formation 5", SalleId = 2, CoursId = 2 });
            modelBuilder.Entity<Machine>().HasData(
                new Machine { Id = 1, Libelle = "Machine 1", Processeur = "Processeur 1", Capacite = "Capacite 1", Memoire = "Memoire 1", Taille_ecran = 27, SalleId=1 },
                new Machine { Id = 2, Libelle = "Machine 2", Processeur = "Processeur 2", Capacite = "Capacite 2", Memoire = "Memoire 2", Taille_ecran = 24, SalleId = 2 });
            modelBuilder.Entity<Cours>().HasData(
                new Cours { Id = 1, Code = "Code 1", Titre = "Titre 1", Duree = 1, Programme = "Programme 1" },
                new Cours { Id = 2, Code = "Code 2", Titre = "Titre 2", Duree = 4, Programme = "Programme 2" },
                new Cours { Id = 3, Code = "Code 3", Titre = "Titre 3", Duree = 15, Programme = "Programme 3" },
                new Cours { Id = 4, Code = "Code 4", Titre = "Titre 4", Duree = 8, Programme = "Programme 4" });
        }
    }
}
