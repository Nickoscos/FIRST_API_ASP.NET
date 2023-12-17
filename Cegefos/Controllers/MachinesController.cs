using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cegefos.API.Models;
using Cegefos.API.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Optimization;
using Microsoft.EntityFrameworkCore;

namespace Cegefos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MachinesController : ControllerBase
    {
        private readonly CatalogueContext _context;

        public MachinesController(CatalogueContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<IActionResult> GetMachines([FromQuery] FormSalMaQueryParameters queryParameters)
        {
            IQueryable<Machine> machines = _context.Machines;

            if (!string.IsNullOrEmpty(queryParameters.Libelle))
            {
                machines = machines.Where(
                    p => p.Libelle.ToLower().Contains(queryParameters.Libelle.ToLower()));
            }

            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (typeof(Machine).GetProperty(queryParameters.SortBy) != null)
                {
                    machines = machines.OrderByCustom(queryParameters.SortBy, queryParameters.SortOrder);
                }
            }
            machines = machines
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return Ok(await machines.ToArrayAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetMachineById(int id)
        {
            var Machine = await _context.Machines.FindAsync(id);
            if (Machine == null)
            {
                return NotFound();
            }
            return Ok(Machine);
        }

        [HttpPost]
        public async Task<ActionResult<Machine>> PostMachine([FromBody] Machine machine)
        {
            _context.Machines.Add(machine);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetMachine",
                new { id = machine.Id },
                machine
                );
        }
    }
}
