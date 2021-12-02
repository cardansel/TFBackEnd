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
    public class AppsController : ControllerBase
    {

        protected readonly TFBackEndApiContext _Context;

        public AppsController(TFBackEndApiContext context)
        {
            _Context = context;
        }

        #region GetAll
        /// <summary>
        /// Metodo que recupera todo el listado
        /// de las aplicaciones
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<AppViewModel>>> GetAll()
        {
            var lstApp = new List<AppViewModel>();
            Respuesta oRespuesta = new Respuesta();

            try
            {
                lstApp = await (from a in _Context.Apps
                                select new AppViewModel
                                {
                                    Id = a.Id,
                                    Nombre = a.Nombre

                                }).ToListAsync();

                oRespuesta.Exito = 1;
                oRespuesta.Data = lstApp;
                return lstApp;
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje=ex.Message;
  
            }

          return Ok(oRespuesta);
            
        }
        #endregion

        #region Save
        public async Task<ActionResult<App>> PostApp(App app)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                if (ModelState.IsValid)
                {
                    _Context.Apps.Add(app);
                    await _Context.SaveChangesAsync();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = app;
                }

                return CreatedAtAction("GetAll", new { id = app.Id }, app);
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }
                return Ok(oRespuesta);

        }
        #endregion
    }
}
