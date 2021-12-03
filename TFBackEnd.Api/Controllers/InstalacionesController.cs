﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFBackEnd.Api.Data;
using TFBackEnd.Api.Models;
using TFBackEnd.Api.Models.Response;
using TFBackEnd.Api.Models.ViewModels;

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
            var lstInstall = new List<Instalacion>();
            Respuesta oRespuesta = new Respuesta();

            try
            {
                /*Esta consulta usa un view model para poder traer la informacion que necesito*/
                //lstInstall =await (from i in _context.Instalaciones
                //              join o in _context.Operarios on i.Operario.Id equals o.Id
                //              join a in _context.Apps on i.App.Id equals a.Id
                //              select new InstalacionViewModel
                //              {
                //                  Id=i.Id,
                //                  Exitosa=i.Exitosa,
                //                  fecha=i.Fecha,
                //                  Operario=o.Nombre,
                //                  App=a.Nombre
                //              }).ToListAsync();

                /*Esta consulta es un poco mas rapida para traer la informacion */

                lstInstall = await _context.Instalaciones
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
                           Apellido = i.Operario.Apellido,

                       },
                       App = new App()
                       {
                           Id = i.App.Id,
                           Nombre = i.App.Nombre
                       }
                       //Telefono = new Telefono()
                       //{
                       //    Id = i.Telefono.Id,
                       //    Marca = i.Telefono.Marca,
                       //    Modelo = i.Telefono.Modelo,
                       //    Precio = i.Telefono.Precio
                       //}


                   }).ToListAsync();

                oRespuesta.Paso = 1;
                oRespuesta.Data = lstInstall;

                return lstInstall;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }

            //  return lstInstall;
        }

        // GET: api/Instalaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instalacion>> GetInstalaciones(int id)
        {
            var instalaciones = await _context.Instalaciones.FindAsync(id);

            if (instalaciones == null)
            {
                return NotFound();
            }

            return instalaciones;
        }

        // PUT: api/Instalaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstalaciones(int id, Instalacion instalaciones)
        {
            Respuesta oRespuesta = new Respuesta();

            if (id != instalaciones.Id)
            {
                return BadRequest();
            }

            instalaciones.Fecha = DateTime.Now;
            _context.Entry(instalaciones).State = EntityState.Modified;

            oRespuesta.Paso = 1;
            oRespuesta.Data = instalaciones;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!InstalacionesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    oRespuesta.Mensaje = ex.Message;
                }

                return Ok(oRespuesta);
            }

            return NoContent();
        }

        // POST: api/Instalaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Instalacion>> PostInstalaciones(Instalacion instalaciones)
        {
            Respuesta oRespuesta = new Respuesta();

            if (ModelState.IsValid)
            {
                instalaciones.Fecha = DateTime.Now;

                _context.Instalaciones.Add(instalaciones);
                oRespuesta.Paso = 1;
                oRespuesta.Data = instalaciones;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                    oRespuesta.Mensaje = ex.Message;

                }
                return Ok(oRespuesta);
            }

            return CreatedAtAction("GetInstalaciones", new { id = instalaciones.Id }, instalaciones);
        }

        // DELETE: api/Instalaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstalaciones(int id)
        {
            Respuesta oRespuesta = new Respuesta();

            var instalaciones = await _context.Instalaciones.FindAsync(id);
            if (instalaciones == null)
            {
                return NotFound();
            }

            try
            {
                _context.Instalaciones.Remove(instalaciones);
                oRespuesta.Paso = 1;
                oRespuesta.Data = instalaciones;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }


            return NoContent();
        }

        private bool InstalacionesExists(int id)
        {
            return _context.Instalaciones.Any(e => e.Id == id);
        }
    }
}
