using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFBackEnd.Api.Data;
using TFBackEnd.Api.Models;

namespace TFBackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstalacionesController : ControllerBase
    {
        private readonly TFBackEndApiContext _context;

        public InstalacionesController(TFBackEndApiContext context)
        {
            _context = context;
        }

        // GET: api/Instalaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instalaciones>>> GetInstalaciones()
        {
            return await _context.Instalaciones.ToListAsync();
        }

        // GET: api/Instalaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instalaciones>> GetInstalaciones(int id)
        {
            var instalaciones = await _context.Instalaciones.FindAsync(id);

            if (instalaciones == null)
            {
                return NotFound();
            }

            return instalaciones;
        }

        // PUT: api/Instalaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstalaciones(int id, Instalaciones instalaciones)
        {
            if (id != instalaciones.Id)
            {
                return BadRequest();
            }

            _context.Entry(instalaciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstalacionesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Instalaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Instalaciones>> PostInstalaciones(Instalaciones instalaciones)
        {
            _context.Instalaciones.Add(instalaciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstalaciones", new { id = instalaciones.Id }, instalaciones);
        }

        // DELETE: api/Instalaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstalaciones(int id)
        {
            var instalaciones = await _context.Instalaciones.FindAsync(id);
            if (instalaciones == null)
            {
                return NotFound();
            }

            _context.Instalaciones.Remove(instalaciones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstalacionesExists(int id)
        {
            return _context.Instalaciones.Any(e => e.Id == id);
        }
    }
}
