using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cegefos.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cegefos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FormationsController : ControllerBase
    {
        private readonly CatalogueContext _context;

        public FormationsController(CatalogueContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IEnumerable<Formation> GetFormations()
        {
            return _context.Formations.ToArray();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFormationById(int id)
        {
            var Formation = await _context.Formations.FindAsync(id);
            if (Formation == null)
            {
                return NotFound();
            }
            return Ok(Formation);
        }
    }
}
