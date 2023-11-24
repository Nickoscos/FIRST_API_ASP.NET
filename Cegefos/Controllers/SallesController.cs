﻿using System;
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
    public class SallesController : ControllerBase
    {
        private readonly CatalogueContext _context;

        public SallesController(CatalogueContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IEnumerable<Salle> GetSalles()
        {
            return _context.Salles.ToArray();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalleById(int id)
        {
            var salle = await _context.Salles.FindAsync(id);
            if (salle == null)
            {
                return NotFound();
            }
            return Ok(salle);
        }
    }
}