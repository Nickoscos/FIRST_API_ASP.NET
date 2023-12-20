using Cegefos.API.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cegefos.API.Classes
{
    public class CoursQueryParameters : QueryParameters
    {
        public string? Titre { get; set; }

        public string? Code { get; set; }

    }
}
