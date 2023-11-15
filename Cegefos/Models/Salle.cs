using System.Text.Json.Serialization;

namespace Cegefos.API.Models
{
    public class Salle
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        /*public virtual List<Machine> Machines { get; set; }*/
        public int Nombre_De_Places { get; set; }
        public virtual List<Formation> Formations { get; set; }
    }
}
