using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using TFBackEnd.Api.Data;
using TFBackEnd.Api.Models;
using TFBackEnd.Api.Models.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TFBackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensoresController : ControllerBase
    {
        private readonly TFBackEndApiContext _context;

        public SensoresController(TFBackEndApiContext context)
        {
            _context = context;
        }

        // GET: api/<SensoresController>
        [HttpGet]
        public async Task<ActionResult<List<Sensor>>> GetSensor()
        {

            try
            {

                return await _context.Sensor
                               .Include(x => x.Telefonos)
                               .AsNoTracking()
                               .ToListAsync();


            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }

            //return lst;
        }

        // GET api/<SensoresController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sensor>> GetById(int? id)
        {
            var sensor = new Sensor();


            try
            {
                if (id == null)
                {
                    return BadRequest();
                }

                sensor = await _context.Sensor.FindAsync(id);

                if (sensor == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Error al intentar recuperar la informacion del registro", ex.Message);
            }


            return sensor;
        }

        // POST api/<SensoresController>
        [HttpPost]
        public async Task<ActionResult<Sensor>> PostSensor(Sensor sensor)
        {
            //Capturar el error cuando da error de list telefonos y sensores
            try
            {

                //Cada Telefono recibido le agrego un sensor
                if (sensor.TelefonosList != null)
                {

                    foreach (var item in sensor.TelefonosList)
                    {
                        Telefono t = await _context.Telefonos.FindAsync(item);
                        sensor.Telefonos.Add(t);
                    }

                }


                _context.Sensor.Add(sensor);

                _context.Sensor.Add(sensor);

                await _context.SaveChangesAsync();
            }
            catch (InvalidCastException ex)
            {

                throw new Exception(ex.ToString());
            }


            //evolvemos el Created con el sensor creado
            return CreatedAtAction("GetSensor", new { id = sensor.Id }, sensor);
        }

        // PUT api/<SensoresController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutSensor(int id, Sensor sensor)
        {
            try
            {
                if (id != sensor.Id)
                {
                    return BadRequest();
                }

                // La variable sensor tendrá la información que recibimos por PUT
                // La variable oSensor tendrá la info original de los sensores con el id recibido

                var oSensor = await _context.Sensor.FindAsync(id);

                // Borraremos los telefonos del sensor para reemplazarlos con los recibidos
                if (oSensor.Telefonos != null)
                {
                    oSensor.Telefonos.Clear();
                }

                await _context.SaveChangesAsync();

                // Esto es importante porque tenemos que avisarle a EF
                // que aquí termina una transacción y comienza otra
                _context.ChangeTracker.Clear();

                //Agregamos a la info de sensores los nuvos telefonos
                if (sensor.TelefonosList != null)
                {
                    foreach (var telId in sensor.TelefonosList)
                    {
                        var telefono = await _context.Telefonos.FindAsync(telId);
                        if (telefono != null)
                        {
                            sensor.Telefonos.Add(telefono);
                        }
                    }
                }

                //Avisamos que hemos modificado el sensor para que EF tome los cambios
                //al guardar
                // _context.Entry(oSensor).State = EntityState.Detached;

                _context.Entry(sensor).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                // return Ok(sensor);
                // Si llegamos aquí es porque todo salió bien
                // devolvemos OK (http 200) y los datos de los sensores

                return CreatedAtAction("GetSensor", new { id = sensor.Id }, sensor);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }

        }

        // DELETE api/<SensoresController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {

            try
            {
                if (id == null)
                {
                    return BadRequest();
                }


                //Busco el sensor que tiene el ID que recibo
                var sensor = await _context.Sensor.FindAsync(id.Value);

                if (sensor == null)
                {
                    return NotFound();
                }

                //Ahora borro el sensor
                _context.Sensor.Remove(sensor);
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
