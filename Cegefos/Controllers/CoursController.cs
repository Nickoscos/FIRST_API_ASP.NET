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
    public class CourssController : ControllerBase
    {
        private readonly CatalogueContext _context;

        public CourssController(CatalogueContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IEnumerable<Cours> GetCourss()
        {
            return _context.Courss.ToArray();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoursById(int id)
        {
            var Cours = await _context.Courss.FindAsync(id);
            if (Cours == null)
            {
                return NotFound();
            }
            return Ok(Cours);
        }
    }
}
