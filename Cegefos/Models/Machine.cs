using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cegefos.API.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Processeur { get; set; }
        public string Memoire { get; set; }
        public string Capacite { get; set; }
        public double Taille_ecran { get; set; }


        public int SalleId { get; set; }
        [JsonIgnore]
        public Salle Salle { get; set; }

    }
}
