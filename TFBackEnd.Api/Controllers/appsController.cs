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
    public class appsController : ControllerBase
    {
        private readonly TFBackEndApiContext _context;

        public appsController(TFBackEndApiContext context)
        {
            _context = context;
        }

        // GET: api/apps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<apps>>> Getapps()
        {
            return await _context.apps.ToListAsync();
        }

        // GET: api/apps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<apps>> Getapps(int id)
        {
            var apps = await _context.apps.FindAsync(id);

            if (apps == null)
            {
                return NotFound();
            }

            return apps;
        }

        // PUT: api/apps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putapps(int id, apps apps)
        {
            if (id != apps.id)
            {
                return BadRequest();
            }

            _context.Entry(apps).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!appsExists(id))
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

        // POST: api/apps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<apps>> Postapps(apps apps)
        {
            _context.apps.Add(apps);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getapps", new { id = apps.id }, apps);
        }

        // DELETE: api/apps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteapps(int id)
        {
            var apps = await _context.apps.FindAsync(id);
            if (apps == null)
            {
                return NotFound();
            }

            _context.apps.Remove(apps);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool appsExists(int id)
        {
            return _context.apps.Any(e => e.id == id);
        }
    }
}
