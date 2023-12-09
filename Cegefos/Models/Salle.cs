using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cegefos.API.Models
{
    public class Salle
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        
        public int Nombre_De_Places { get; set; }
        public List<Machine> Machines { get; set; }

    }
}
