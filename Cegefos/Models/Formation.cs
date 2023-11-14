using System.Text.Json.Serialization;

namespace Cegefos.API.Models
{
    public class Formation
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public DateTime DateDebut { get; set; }
        public int CoursId { get; set; }

        public int SalleId { get; set; }

        [JsonIgnore]
        public virtual Cours Cours { get; set; }
        [JsonIgnore]
        public virtual Salle Salle { get; set; }
    }
}
