using Microsoft.AspNetCore.Mvc;

namespace Cegefos.API.Controllers
{
    public class FormationController
    {
        [Route("[controller]")]
        [ApiController]
        public class FormationsController : ControllerBase 
        {
            private readonly CatalogueContext _context;
        }
    }
}
