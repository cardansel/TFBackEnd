using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFBackEnd.Api.Data;
using TFBackEnd.Api.Models;
using TFBackEnd.Api.Models.ViewModels;

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
                //var list = await _context.Apps.ToListAsync();
                var list = await _context.Apps
                     .Include(x => x.Instalaciones)
                         .ThenInclude(x => x.Operario.Instalaciones)

                     .ToListAsync();

                return list;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }

        }

      [HttpGet("Operaciones")]
      public async Task<ActionResult<List<App>>>GetAllByName(string apli)
        {
            try
            {
                List<App> apps =await _context.Apps.Where(x=>x.Nombre.Equals(apli))
                            .Include(x=>x.Instalaciones)
                               .ThenInclude(x=>x.Telefono)
                            .ToListAsync();

                return apps;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        // GET: api/Apps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<App>> GetApp(int? id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }
                var app = await _context.Apps.FindAsync(id.Value);

                if (app == null)
                {
                    return NotFound();
                }

                return app;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }

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

            //return NoContent();
            return CreatedAtAction("GetApp", new { id = app.Id }, app);
        }

        // POST: api/Apps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<App>> PostApp(App app)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Apps.Add(app);
                    await _context.SaveChangesAsync();
                }

                return CreatedAtAction("GetApp", new { id = app.Id }, app);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
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

            //return NoContent();
            return CreatedAtAction("GetApp", new { id = app.Id }, app);
        }

        private bool AppExists(int id)
        {
            //retorna 
            return _context.Apps.Any(e => e.Id == id);
        }
    }
}
