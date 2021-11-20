using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFBackEnd.Api.Data;
using TFBackEnd.Models;

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
        public async Task<ActionResult<IEnumerable<Instalacion>>> GetInstalaciones()
        {
            return await _context.Instalaciones.ToListAsync();
        }

        // GET: api/Instalaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instalacion>> GetInstalacion(int id)
        {
            var instalacion = await _context.Instalaciones.FindAsync(id);

            if (instalacion == null)
            {
                return NotFound();
            }

            return instalacion;
        }

        // PUT: api/Instalaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstalacion(int id, Instalacion instalacion)
        {
            if (id != instalacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(instalacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstalacionExists(id))
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
        public async Task<ActionResult<Instalacion>> PostInstalacion(Instalacion instalacion)
        {
            instalacion.Fecha = DateTime.Now;
            _context.Instalaciones.Add(instalacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstalacion", new { id = instalacion.Id }, instalacion);
        }

        // DELETE: api/Instalaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstalacion(int id)
        {
            var instalacion = await _context.Instalaciones.FindAsync(id);
            if (instalacion == null)
            {
                return NotFound();
            }

            _context.Instalaciones.Remove(instalacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstalacionExists(int id)
        {
            return _context.Instalaciones.Any(e => e.Id == id);
        }
    }
}
