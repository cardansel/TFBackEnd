using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFBackEnd.Api.Data;
using TFBackEnd.Api.Models;
using TFBackEnd.Api.Models.Response;
using TFBackEnd.Api.Models.ViewModels;

namespace TFBackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperarioController : ControllerBase
    {

        protected readonly TFBackEndApiContext _context;

        public OperarioController(TFBackEndApiContext context)
        {
            _context = context;
        }

        #region GetAll

        /// <summary>
        /// Metodo para mostrar los registro de
        /// los operarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperarioViewModel>>> GetAll()
        {
            var lstOperario = new List<OperarioViewModel>();
            Respuesta oRespuesta = new Respuesta();
            try
            {
                lstOperario = await (from o in _context.Operarios
                                     select new OperarioViewModel
                                     {
                                         Id = o.Id,
                                         Nombre = o.Nombre,
                                         Apellido = o.Apellido
                                     }).ToListAsync();

                oRespuesta.Paso = 1;
                oRespuesta.Data = lstOperario;

                return lstOperario;

            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;

            }

            return Ok(oRespuesta);


        }
        #endregion

        #region GetById
        /// <summary>
        /// Muestra la informacion de 
        /// un registro por su Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Operario>> GetById(int? id)
        {


            try
            {
                if (id == null)
                {
                    return NotFound();

                }

                var operario = await _context.Operarios.FindAsync(id);

                if (operario == null)
                {
                    return NotFound();
                }

                return operario;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        #endregion

        #region Save
        /// <summary>
        /// Crea un nuevo registro 
        /// </summary>
        /// <param name="operario"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Operario>> PostOperario(Operario operario)
        {
            Respuesta oRespuesta = new Respuesta();

            if (ModelState.IsValid)
            {
                _context.Operarios.Add(operario);
                oRespuesta.Paso = 1;
                oRespuesta.Data = operario;
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

            return CreatedAtAction("GetAll", new { id = operario.Id }, operario);
        }
        #endregion

        #region Edit
        /// <summary>
        /// Metodo para editar y actualizar 
        /// un registro
        /// </summary>
        /// <param name="operario"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperario(int id, Operario operario)
        {
            Respuesta oRespuesta = new Respuesta();

            if (id != operario.Id)
            {
                return BadRequest();
            }

            _context.Entry(operario).State = EntityState.Modified;

            oRespuesta.Paso = 1;
            oRespuesta.Data = operario;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!OperariosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    oRespuesta.Mensaje = ex.Message;
                }

                return Ok(oRespuesta);
            }

            //return NoContent();
            return CreatedAtAction("GetAll", new { id = operario.Id }, operario);
        }

        #endregion

        #region Delete
        /// <summary>
        /// Metodo para eliminar un registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Respuesta oRespuesta = new Respuesta();

            var operario = await _context.Operarios.FindAsync(id);
            if (operario == null)
            {
                return NotFound();
            }

            try
            {
                _context.Operarios.Remove(operario);
                oRespuesta.Paso = 1;
                oRespuesta.Data = operario;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }


            return NoContent();
        }
        #endregion

        #region Existe
        /// <summary>
        /// Metodo que verifica
        /// si existe un registro con el
        /// Id asignado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool OperariosExists(int id)
        {
            return _context.Operarios.Any(e => e.Id == id);
        }
        #endregion
    }
}
