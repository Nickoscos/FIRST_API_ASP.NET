using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cegefos.API.Models;
using Cegefos.API.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Optimization;

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
        public async Task<IActionResult> GetFormations([FromQuery] FormSalMaQueryParameters queryParameters)
        {
            IQueryable<Formation> formations = _context.Formations;

            if (!string.IsNullOrEmpty(queryParameters.Libelle))
            {
                formations = formations.Where(
                    p => p.Libelle.ToLower().Contains(queryParameters.Libelle.ToLower()));
            }

            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (typeof(Formation).GetProperty(queryParameters.SortBy) != null)
                {
                    formations = formations.OrderByCustom(queryParameters.SortBy, queryParameters.SortOrder);
                }
            }
            formations = formations
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size)
                .Include(t => t.Salle.Machines)
                .Include(t => t.Cours);

            return Ok(await formations.ToArrayAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFormationById(int id)
        {
            IQueryable<Formation> formations = _context.Formations;

            var formation = formations.Where(f => f.Id == id)
                .Include(f => f.Salle)
                .Include(f => f.Cours);

            if (formation == null)
            {
                return NotFound();
            }
            return Ok(await formation.FirstAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Formation>> PostFormation([FromBody] Formation formation)
        {
            _context.Formations.Add(formation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetFormation",
                new { id = formation.Id },
                formation
                );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormation([FromRoute] int id, [FromBody] Formation formation)
        {
            if (id != formation.Id)
            {
                return BadRequest();
            }

            _context.Entry(formation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Formations.Find(id) == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Formation>> DeleteFormation(int id)
        {
            var formation = await _context.Formations.FindAsync(id);
            if (formation == null)
            {
                return NotFound();
            }

            _context.Formations.Remove(formation);
            await _context.SaveChangesAsync();

            return formation;
        }
    }
}
