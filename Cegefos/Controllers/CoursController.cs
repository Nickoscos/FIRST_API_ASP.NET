using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cegefos.API.Classes;
using Cegefos.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetCourss([FromQuery] CoursQueryParameters queryParameters)
        {
            IQueryable<Cours> cours = _context.Courss;

            if (!string.IsNullOrEmpty(queryParameters.Titre))
            {
                cours = cours.Where(
                    p => p.Titre.ToLower().Contains(queryParameters.Titre.ToLower()));
            }

            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (typeof(Cours).GetProperty(queryParameters.SortBy) != null)
                {
                    cours = cours.OrderByCustom(queryParameters.SortBy, queryParameters.SortOrder);
                }
            }

            cours = cours
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return Ok(await cours.ToArrayAsync());
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

        [HttpPost]
        public async Task<ActionResult<Cours>> PostCours([FromBody] Cours cours)
        {
            _context.Courss.Add(cours);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetCours",
                new { id = cours.Id },
                cours
                );
        }
    }
}
