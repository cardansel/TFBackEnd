using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFBackEnd.Api.Data;
using TFBackEnd.Api.Models;
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

            try
            {
                lstOperario = await (from o in _context.Operarios
                                     select new OperarioViewModel
                                     {
                                         Id = o.Id,
                                         Nombre = o.Nombre,
                                         Apellido = o.Apellido
                                     }).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }

            return lstOperario;
        }
        #endregion



    }
}
