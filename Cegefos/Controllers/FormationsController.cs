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
            IQueryable<Formation> formations = _context.Formations.Include(t => t.Salle.Machines).Include(t => t.Cours);

            if (!string.IsNullOrEmpty(queryParameters.Libelle))
            {
                formations = formations.Where(
                    p => p.Libelle.ToLower().Contains(queryParameters.Libelle.ToLower()));
            }

            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (typeof(Salle).GetProperty(queryParameters.SortBy) != null)
                {
                    formations = formations.OrderByCustom(queryParameters.SortBy, queryParameters.SortOrder);
                }
            }
            formations = formations
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return Ok(await formations.ToArrayAsync());
        }
        /*        public async Task<List<Formation>> GetFormations()
                {
                    var formation = await _context.Formations.Include(t => t.Salle.Machines).Include(t => t.Cours).ToListAsync();

                    return formation;
                }*/

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFormationById(int id)
        {
            var Formation = await _context.Formations.Include(t => t.Salle.Machines).Include(t => t.Cours).Where(m => m.Id == id).ToListAsync();
            if (Formation == null)
            {
                return NotFound();
            }
            return Ok(Formation);
        }
    }
}
