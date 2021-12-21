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
        public async Task<ActionResult<IEnumerable<Instalacion>>> GetInstalaciones()
        {
            try
            {
                var instalacion =await _context.Instalaciones
                              .Include(i => i.Operario)
                              .Include(i => i.App)
                              .Include(i => i.Telefono)
                              .Select(i => new Instalacion()
                              {
                                  Id = i.Id,
                                  Exitosa = i.Exitosa,
                                  Fecha = i.Fecha,
                                  Operario = new Operario()
                                  {
                                      Nombre = i.Operario.Nombre,
                                      Apellido = i.Operario.Apellido
                                  },
                                  App = new App()
                                  {
                                      Nombre = i.App.Nombre
                                  },
                                  Telefono = new Telefono()
                                  {
                                      Marca = i.Telefono.Marca,
                                      Modelo = i.Telefono.Modelo,
                                      Precio = i.Telefono.Precio
                                  }
                              }).ToListAsync();

                return instalacion;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
            
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

            instalacion.Fecha = DateTime.Now;
            _context.Entry(instalacion).State = EntityState.Modified;

            if (instalacion==null)
            {
                return NotFound();
            }
            
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
            try
            {
                if (ModelState.IsValid)
                {
                    instalacion.Fecha = DateTime.Now;
                    _context.Instalaciones.Add(instalacion);
                    await _context.SaveChangesAsync();
                }

                //return instalacion;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }


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
