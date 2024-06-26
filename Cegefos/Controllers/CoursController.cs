﻿using System;
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
    [ApiVersion("1.0")]
    [Route("cours")]
    [ApiController]
    public class Cours_V1_0Controller : ControllerBase
    {
        private readonly CatalogueContext _context;

        public Cours_V1_0Controller(CatalogueContext context)
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
                "GetCourss",
                new { id = cours.Id },
                cours
                );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCours([FromRoute] int id, [FromBody] Cours cours)
        {
            if (id != cours.Id)
            {
                return BadRequest();
            }

            _context.Entry(cours).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Courss.Find(id) == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cours>> DeleteCours(int id)
        {
            var cours = await _context.Courss.FindAsync(id);
            if (cours == null)
            {
                return NotFound();
            }

            _context.Courss.Remove(cours);
            await _context.SaveChangesAsync();

            return cours;
        }
    }

    [ApiVersion("2.0")]
    [Route("cours")]
    [ApiController]
    public class Cours_V2_0Controller : ControllerBase
    {
        private readonly CatalogueContext _context;

        public Cours_V2_0Controller(CatalogueContext context)
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

            if (!string.IsNullOrEmpty(queryParameters.Code))
            {
                cours = cours.Where(
                    p => p.Code.ToLower().Contains(queryParameters.Code.ToLower()));
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
                "GetCourss",
                new { id = cours.Id },
                cours
                );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCours([FromRoute] int id, [FromBody] Cours cours)
        {
            if (id != cours.Id)
            {
                return BadRequest();
            }

            _context.Entry(cours).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Courss.Find(id) == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cours>> DeleteCours(int id)
        {
            var cours = await _context.Courss.FindAsync(id);
            if (cours == null)
            {
                return NotFound();
            }

            _context.Courss.Remove(cours);
            await _context.SaveChangesAsync();

            return cours;
        }
    }
}
