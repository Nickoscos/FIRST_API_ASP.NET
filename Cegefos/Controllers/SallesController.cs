using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cegefos.API.Models;
using Cegefos.API.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cegefos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SallesController : ControllerBase
    {
        private readonly CatalogueContext _context;

        public SallesController(CatalogueContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<IActionResult> GetSalles([FromQuery] FormSalMaQueryParameters queryParameters)
        {
            IQueryable<Salle> salles = _context.Salles.Include(t => t.Machines);

            if (!string.IsNullOrEmpty(queryParameters.Libelle))
            {
                salles = salles.Where(
                    p => p.Libelle.ToLower().Contains(queryParameters.Libelle.ToLower()));
            }

            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (typeof(Salle).GetProperty(queryParameters.SortBy) != null)
                {
                    salles = salles.OrderByCustom(queryParameters.SortBy, queryParameters.SortOrder);
                }
            }

            salles = salles
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return Ok(await salles.ToArrayAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalleById(int id)
        {
            var salle = await _context.Salles.Include(s => s.Machines).Where(m => m.Id == id).ToListAsync();
            if (salle == null)
            {
                return NotFound();
            }
            return Ok(salle);
        }

        [HttpGet("{id}/machines")]
        public IActionResult GetMachinesBySalleId(int id)
        {
            var salle = _context.Salles.Include(s => s.Machines).Where(m => m.Id==id).FirstOrDefault();

            if (salle == null)
            {
                return NotFound();
            }

            return Ok(salle.Machines);
        }

        [HttpPost]
        public async Task<ActionResult<Salle>> PostSalle([FromBody] Salle salle)
        {
            _context.Salles.Add(salle);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetSalle",
                new { id = salle.Id },
                salle
                );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalle([FromRoute] int id, [FromBody] Salle salle)
        {
            if (id != salle.Id)
            {
                return BadRequest();
            }

            _context.Entry(salle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Salles.Find(id) == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Salle>> DeleteSalle(int id)
        {
            var salle = await _context.Salles.FindAsync(id);
            if (salle == null)
            {
                return NotFound();
            }

            _context.Salles.Remove(salle);
            await _context.SaveChangesAsync();

            return salle;
        }
    }


}

