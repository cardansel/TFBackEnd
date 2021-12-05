using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFBackEnd.Api.Data;
using TFBackEnd.Api.Models;
using TFBackEnd.Api.Models.Response;

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
        #region GetAll
        /// <summary>
        /// Metodo que devuelve 
        /// un listado de las App 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<App>>> GetApps()
        {
            var lstApp = new List<App>();
            Respuesta oRespuesta = new Respuesta();

            try
            {

                lstApp = await _context.Apps.ToListAsync();

                oRespuesta.Paso = 1;
                oRespuesta.Data = lstApp;

                return lstApp;

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);

        }
        #endregion


        #region GetById
        // GET: api/Apps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<App>> GetApp(int? id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var app = await _context.Apps.FindAsync(id);
                oRespuesta.Paso = 1;
                oRespuesta.Data = app;
                if (app == null)
                {
                    return NotFound();
                }

                return app;
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }


            return Ok(oRespuesta);

        }
        #endregion


        #region Update
        /// <summary>
        /// Metodo para actualizar un registro
        /// a traves de su Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="app"></param>
        /// <returns></returns>
        // PUT: api/Apps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApp(int id, App app)
        {

            Respuesta oRespuesta = new Respuesta();

            if (id != app.Id)
            {
                return BadRequest();
            }

            _context.Entry(app).State = EntityState.Modified;

            try
            {
                oRespuesta.Paso = 1;
                oRespuesta.Data = app;
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
                    return Ok(oRespuesta);
                }
            }

            return NoContent();
        }
        #endregion


        #region Create
        /// <summary>
        /// Meto que permite agregar 
        /// un nuevo registro
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        // POST: api/Apps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<App>> PostApp(App app)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Apps.Add(app);
                    oRespuesta.Paso = 1;
                    oRespuesta.Data = app;

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return CreatedAtAction("GetApp", new { id = app.Id }, app);
        }
        #endregion

        #region Delete
        /// <summary>
        /// Metodo que permite eliminar 
        /// un registro a trves de su Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Apps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApp(int? id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var app = await _context.Apps.FindAsync(id);
                oRespuesta.Paso = 1;
                oRespuesta.Data = app;

                if (app == null)
                {
                    return NotFound();
                }
                _context.Apps.Remove(app);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetApp", new { id = app.Id }, app);
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }


            return Ok(oRespuesta);
        }

        #endregion



        private bool AppExists(int id)
        {
            return _context.Apps.Any(e => e.Id == id);
        }
    }
}
