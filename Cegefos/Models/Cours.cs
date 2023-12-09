using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cegefos.API.Models
{
    public class Cours
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Titre { get; set; }
        public int Duree { get; set; }
        public string Programme { get; set; }
        /*[JsonIgnore]
        public Salle Salle { get; set; }
                 [JsonIgnore]
        public Formation Formation { get; set; }

        [JsonIgnore]
        public int SalleId { get; set; }*/

/*        [JsonIgnore]
        public Formation Formation { get; set; }*/




    }
}
