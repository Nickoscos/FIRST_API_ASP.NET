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
    public class MachinesController : ControllerBase
    {
        private readonly CatalogueContext _context;

        public MachinesController(CatalogueContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IEnumerable<Machine> GetMachines()
        {
            return _context.Machines.ToArray();
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
    }
}
