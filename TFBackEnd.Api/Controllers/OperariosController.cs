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
    public class OperariosController : ControllerBase
    {
        private readonly TFBackEndApiContext _context;

        public OperariosController(TFBackEndApiContext context)
        {
            _context = context;
        }

        // GET: api/Operarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operario>>> GetOperarios()
        {
            return await _context.Operarios.ToListAsync();
        }

        // GET: api/Operarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Operario>> GetOperario(int id)
        {
            var operario = await _context.Operarios.FindAsync(id);

            if (operario == null)
            {
                return NotFound();
            }

            return operario;
        }

        // PUT: api/Operarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperario(int id, Operario operario)
        {
            if (id != operario.Id)
            {
                return BadRequest();
            }

            _context.Entry(operario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperarioExists(id))
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

        // POST: api/Operarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Operario>> PostOperario(Operario operario)
        {
            _context.Operarios.Add(operario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperario", new { id = operario.Id }, operario);
        }

        // DELETE: api/Operarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperario(int id)
        {
            var operario = await _context.Operarios.FindAsync(id);
            if (operario == null)
            {
                return NotFound();
            }

            _context.Operarios.Remove(operario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperarioExists(int id)
        {
            return _context.Operarios.Any(e => e.Id == id);
        }
    }
}
