using System.Text.Json.Serialization;

namespace Cegefos.API.Models
{
    public class Formation
    {
        public int Id { get; set; }
        public string? Libelle { get; set; }
/*        public int SalleId { get; set; }
        [JsonIgnore]
        public virtual Salle Salle { get; set; }*/
    }
}
