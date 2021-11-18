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
    public class OperariosController : ControllerBase
    {
        private readonly TFBackEndApiContext _context;

        public OperariosController(TFBackEndApiContext context)
        {
            _context = context;
        }

        // GET: api/Operarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operarios>>> GetOperarios()
        {
            return await _context.Operarios.ToListAsync();
        }

        // GET: api/Operarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Operarios>> GetOperarios(int id)
        {
            var operarios = await _context.Operarios.FindAsync(id);

            if (operarios == null)
            {
                return NotFound();
            }

            return operarios;
        }

        // PUT: api/Operarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperarios(int id, Operarios operarios)
        {
            if (id != operarios.id)
            {
                return BadRequest();
            }

            _context.Entry(operarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperariosExists(id))
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
        public async Task<ActionResult<Operarios>> PostOperarios(Operarios operarios)
        {
            _context.Operarios.Add(operarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperarios", new { id = operarios.id }, operarios);
        }

        // DELETE: api/Operarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperarios(int id)
        {
            var operarios = await _context.Operarios.FindAsync(id);
            if (operarios == null)
            {
                return NotFound();
            }

            _context.Operarios.Remove(operarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperariosExists(int id)
        {
            return _context.Operarios.Any(e => e.id == id);
        }
    }
}
