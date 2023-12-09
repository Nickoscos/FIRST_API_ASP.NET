﻿using ContosoUniversity.Models;
using System.Text.Json.Serialization;

namespace Cegefos.API.Models
{
    public class Formation
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public Salle Salle { get; set; }
        [JsonIgnore]
        public int SalleId { get; set; }

    }
}
