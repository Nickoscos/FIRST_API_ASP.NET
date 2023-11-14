using Microsoft.EntityFrameworkCore;

namespace Cegefos.API.Models
{
    public class ModelBuidlerExtensions
    {
        public static class ModelBuilderExtensions
        {
            public static void Seed(this ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Salle>().HasData(
                    new Salle { Id = 1, Libelle = "Zeus", Nombre_De_Places = 10 },
                    new Salle { Id = 2, Libelle = "Athéna", Nombre_De_Places = 15 },
                    new Salle { Id = 3, Libelle = "Poséidon", Nombre_De_Places = 5 }
                    );

                modelBuilder.Entity<Machine>().HasData(
                    new Machine { Id = 1, Libelle = "Machine 1", Processeur = "Processeur 1", Memoire = "Memoire 1", Capacite = "Capacite 1", Taille_Ecran = 10},
                    new Machine { Id = 2, Libelle = "Machine 2", Processeur = "Processeur 2", Memoire = "Memoire 2", Capacite = "Capacite 2", Taille_Ecran = 20 },
                    new Machine { Id = 3, Libelle = "Machine 3", Processeur = "Processeur 3", Memoire = "Memoire 3", Capacite = "Capacite 3", Taille_Ecran = 30 },
                    new Machine { Id = 4, Libelle = "Machine 4", Processeur = "Processeur 4", Memoire = "Memoire 4", Capacite = "Capacite 4", Taille_Ecran = 40 },
                    new Machine { Id = 5, Libelle = "Machine 5", Processeur = "Processeur 5", Memoire = "Memoire 5", Capacite = "Capacite 5", Taille_Ecran = 50 }
                    );

                modelBuilder.Entity<Cours>().HasData(
                    new Cours { Id = 1, Titre = "Cours 1", Code = "Code 1", Duree = 1, Programme = "Programme 1"},
                    new Cours { Id = 2, Titre = "Cours 2", Code = "Code 2", Duree = 2, Programme = "Programme 2" },
                    new Cours { Id = 3, Titre = "Cours 3", Code = "Code 3", Duree = 3, Programme = "Programme 3" },
                    new Cours { Id = 4, Titre = "Cours 4", Code = "Code 4", Duree = 4, Programme = "Programme 4" }
                    );

                modelBuilder.Entity<Formation>().HasData(
                    new Formation { Id = 1, Libelle="Formation 1", CoursId = 1, SalleId=1, DateDebut= new DateTime(2023, 10, 12, 8, 30, 00) },
                    new Formation { Id = 2, Libelle = "Formation 2", CoursId = 2, SalleId = 2, DateDebut = new DateTime(2023, 10, 12, 8, 30, 00) }
                    );


            }
        }
    }
}
