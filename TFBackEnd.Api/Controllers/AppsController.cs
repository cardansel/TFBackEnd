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
    public class AppsController : ControllerBase
    {
        private readonly TFBackEndApiContext _context;

        public AppsController(TFBackEndApiContext context)
        {
            _context = context;
        }

        // GET: api/Apps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<App>>> GetApps()
        {
            try
            {
                return await _context.Apps.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        // GET: api/Apps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<App>> GetApp(int id)
        {
            var app = await _context.Apps.FindAsync(id);

            if (app == null)
            {
                return NotFound();
            }

            return app;
        }

        // PUT: api/Apps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApp(int id, App app)
        {
            if (id != app.Id)
            {
                return BadRequest();
            }

            _context.Entry(app).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppExists(id))
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

        // POST: api/Apps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<App>> PostApp(App app)
        {
            _context.Apps.Add(app);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApp", new { id = app.Id }, app);
        }

        // DELETE: api/Apps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApp(int id)
        {
            var app = await _context.Apps.FindAsync(id);
            if (app == null)
            {
                return NotFound();
            }

            _context.Apps.Remove(app);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppExists(int id)
        {
            return _context.Apps.Any(e => e.Id == id);
        }
    }
}
