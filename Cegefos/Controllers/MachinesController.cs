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
    [ApiVersion("1.0")]
    [Route("machines")]
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
                "GetMachines",
                new { id = machine.Id },
                machine
                );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMachine([FromRoute] int id, [FromBody] Machine machine)
        {
            if (id != machine.Id)
            {
                return BadRequest();
            }

            _context.Entry(machine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Machines.Find(id) == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Machine>> DeleteMachine(int id)
        {
            var machine = await _context.Machines.FindAsync(id);
            if (machine == null)
            {
                return NotFound();
            }

            _context.Machines.Remove(machine);
            await _context.SaveChangesAsync();

            return machine;
        }
    }
}
