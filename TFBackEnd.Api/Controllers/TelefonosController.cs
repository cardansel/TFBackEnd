using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFBackEnd.Api.Data;
using TFBackEnd.Api.Models;
using TFBackEnd.Api.Models.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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


        // GET: api/<TelefonosController>
        [HttpGet]
        public async Task<ActionResult<List<Telefono>>> GetTelefonos()
        {
            try
            {
                return await _context.Telefonos
                      .Include(x => x.Sensores)

                          .AsNoTracking()
                      .ToListAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }

        }


        [HttpGet("search")]
        public async Task<dynamic> Search(string sensor = "Giroscopio", string aplicacion = "WhatsApp")
        {
            try
            {
                return await _context.Instalaciones.Where(item => item.App.Nombre == aplicacion)
                                   .Select(item => new
                                   {
                                       App = item.App.Nombre,
                                       Sensor = item.Telefono.Sensores.Where(item => item.Nombre == sensor)
                                           .Select(item => new
                                           {
                                               item.Nombre,
                                               Telefono = item.Telefonos.Select(item => new
                                               {
                                                   item.Marca,
                                                   item.Modelo
                                               })
                                           })

                                   }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        // GET api/<TelefonosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Telefono>> GetById(int? id)
        {
            var telefono = new Telefono();

            try
            {
                if (id == null)
                {
                    return BadRequest();
                }

                telefono = await _context.Telefonos.FindAsync(id.Value);

                if (telefono == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }

            return telefono;
        }

        // POST api/<TelefonosController>
        [HttpPost]
        public async Task<ActionResult<Telefono>> PostTelefono(Telefono telefono)
        {
            try
            {
                //Cada Sensor recibe un telefono
                foreach (var item in telefono.SensoresList)
                {
                    Sensor s = await _context.Sensor.FindAsync(item);
                    telefono.Sensores.Add(s);
                }


                _context.Telefonos.Add(telefono);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTelefonos", new { id = telefono.Id }, telefono);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        // PUT api/<TelefonosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutTelefono(int id, Telefono telefono)
        {
            try
            {
                if (id != telefono.Id)
                {
                    return BadRequest();
                }

                // La variable telefono tendrá la información que recibimos por PUT
                // La variable tel tendrá la info original de los tlefonos con el id recibido

                var tel = await _context.Telefonos.FindAsync(id);

                // Borraremos los telefonos del sensor para reemplazarlos con los recibidos
                if (tel.Sensores != null)
                {
                    tel.Sensores.Clear();
                }

                await _context.SaveChangesAsync();

                // Esto es importante porque tenemos que avisarle a EF
                // que aquí termina una transacción y comienza otra
                _context.ChangeTracker.Clear();

                //Agregamos a la info de sensores los nuvos telefonos
                if (tel.SensoresList != null)
                {
                    foreach (var Idsensor in tel.SensoresList)
                    {
                        var sensor = await _context.Sensor.FindAsync(Idsensor);
                        if (sensor != null)
                        {
                            telefono.Sensores.Add(sensor);
                            //_context.Entry(telefono.Sensores).State = EntityState.Modified;
                        }
                        //else
                        //{
                        //    telefono.Sensores.Add(sensor);
                        //}
                    }
                }
                //Avisamos que hemos modificado el sensor para que EF tome los cambios
                //al guardar
                _context.Entry(telefono).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                // Si llegamos aquí es porque todo salió bien
                // devolvemos OK (http 200) y los datos de los sensores
                return Ok(telefono);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        // DELETE api/<TelefonosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {

            try
            {
                if (id == null)
                {
                    return BadRequest();
                }


                //Busco el telefono que tiene el ID que recibo
                var telefono = await _context.Telefonos.FindAsync(id);

                if (telefono == null)
                {
                    return NotFound();
                }

                //Ahora borro el telefono
                _context.Telefonos.Remove(telefono);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
            // Devolvemos NO CONTENT porque ya no existe
            return NoContent();
        }
    }
}
