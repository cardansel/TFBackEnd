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
    public class TelefonosController : ControllerBase
    {
        private readonly TFBackEndApiContext _context;

        public TelefonosController(TFBackEndApiContext context)
        {
            _context = context;
        }

        // GET: api/Telefonos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telefonos>>> GetTelefonos()
        {
            return await _context.Telefonos.ToListAsync();
        }

        // GET: api/Telefonos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Telefonos>> GetTelefonos(int id)
        {
            var telefonos = await _context.Telefonos.FindAsync(id);

            if (telefonos == null)
            {
                return NotFound();
            }

            return telefonos;
        }

        // PUT: api/Telefonos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelefonos(int id, Telefonos telefonos)
        {
            if (id != telefonos.id)
            {
                return BadRequest();
            }

            _context.Entry(telefonos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefonosExists(id))
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

        // POST: api/Telefonos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Telefonos>> PostTelefonos(Telefonos telefonos)
        {
            _context.Telefonos.Add(telefonos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTelefonos", new { id = telefonos.id }, telefonos);
        }

        // DELETE: api/Telefonos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTelefonos(int id)
        {
            var telefonos = await _context.Telefonos.FindAsync(id);
            if (telefonos == null)
            {
                return NotFound();
            }

            _context.Telefonos.Remove(telefonos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TelefonosExists(int id)
        {
            return _context.Telefonos.Any(e => e.id == id);
        }
    }
}
