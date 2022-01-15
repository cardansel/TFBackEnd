using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        [HttpGet("Search")]
        public async Task<dynamic> Search(bool status = true)
        {
            try
            {
                return await _context.Instalaciones.Where(x=>x.Exitosa==status)
                            .Include(x=>x.Operario)
                            .Include(x=>x.Telefono)
                            .Include(x=>x.App)
                            .Select(x => new Instalacion
                            {
                                Id = x.Id,
                                Exitosa = x.Exitosa,
                                Fecha = x.Fecha,

                                App = new App
                                {
                                    Nombre = x.App.Nombre
                                },

                                Operario = new Operario
                                {
                                    Nombre = x.Operario.Nombre,
                                    Apellido = x.Operario.Apellido
                                },

                                Telefono = new Telefono
                                {
                                    Marca = x.Telefono.Marca,
                                    Modelo = x.Telefono.Modelo
                                }
                            })
                            .ToListAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString()); ;
            }
        }

  


        // GET: api/Instalaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instalacion>>> GetInstalaciones()
        {
            try
            {

                var listado = await _context.Instalaciones
                               .Include(x => x.App)
                                .Include(x => x.Operario.Instalaciones)
                                .Include(x => x.Telefono.Instalaciones)
                                .Select(x => new Instalacion
                                {
                                    Id = x.Id,
                                    Exitosa = x.Exitosa,
                                    Fecha = x.Fecha,

                                    App = new App
                                    {
                                        Nombre = x.App.Nombre
                                    },

                                    Operario = new Operario
                                    {
                                        Nombre = x.Operario.Nombre,
                                        Apellido = x.Operario.Apellido
                                    },

                                    Telefono = new Telefono
                                    {
                                        Marca = x.Telefono.Marca,
                                        Modelo = x.Telefono.Modelo
                                    }
                                })
                               .ToListAsync();

                

                return listado;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        // GET: api/Instalaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instalacion>> GetInstalacion(int? id)
        {

            try
            {
                if (id == null)
                {
                    return BadRequest();
                }

                var instalacion = await _context.Instalaciones.FindAsync(id.Value);

                if (instalacion == null)
                {
                    return NotFound();
                }


                var model = await _context.Instalaciones.Where(x => x.Id == id)
                                        .Include(x => x.App)
                                        .Include(x => x.Operario)
                                        .Include(x => x.Telefono)
                                        .Select(x => new Instalacion
                                        {
                                            Id = x.Id,
                                            Exitosa = x.Exitosa,
                                            Fecha = x.Fecha,

                                            Operario = new Operario
                                            {
                                                Nombre = x.Operario.Nombre,
                                                Apellido = x.Operario.Apellido
                                            },

                                            App = new App
                                            {
                                                Nombre = x.App.Nombre
                                            },
                                            Telefono = new Telefono
                                            {
                                                Marca = x.Telefono.Marca,
                                                Modelo = x.Telefono.Modelo,
                                                Instalaciones=x.Telefono.Instalaciones
                                            }
                                        })
                                .FirstOrDefaultAsync();



                return model;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }


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

            if (instalacion == null)
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
                    int result = await _context.SaveChangesAsync();

                    if (result == 0)
                        return NotFound();
                    else
                        return Ok(instalacion.Id);
                }

                return NotFound();
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
