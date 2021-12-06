using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFBackEnd.Api.Data;
using TFBackEnd.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TFBackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperariosController : ControllerBase
    {
        private readonly TFBackEndApiContext _context;

        public OperariosController(TFBackEndApiContext context)
        {
            _context = context;
        }


        // GET: api/<OperariosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operario>>> GetOperarios()
        {
            try
            {
                return await _context.Operarios.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        [HttpGet("InstallDate")]
        public async Task<dynamic> installDate(DateTime date)
        {
            date = date.Date;

            try
            {
                return await _context.Operarios
                        .Select(item => new
                        {
                            item.Nombre,
                            item.Apellido,
                            apliInstall = _context.Instalaciones
                                .Where(i => i.Fecha.Date == date &&
                                        i.Exitosa == true &&
                                        i.Operario.Id == item.Id)
                                .Count()
                        }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        // GET api/<OperariosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Operario>> GetByIdOperario(int? id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest();
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

        // POST api/<OperariosController>
        [HttpPost]
        public async Task<ActionResult<Operario>> PostOperario(Operario operario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Operarios.Add(operario);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return CreatedAtAction("GetOperarios", new { id = operario.Id }, operario);
        }

        // PUT api/<OperariosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperario(int id,Operario operario)
        {
            if (id != operario.Id)
            {
                return BadRequest();
            }

            _context.Entry(operario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOperarios",new { id=operario.Id},operario);
        }

        // DELETE api/<OperariosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperario(int id)
        {
            var operario = await _context.Operarios.FindAsync(id);
            if (operario == null)
            {
                return NotFound();
            }

            _context.Operarios.Remove(operario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperarios",new { id=operario.Id},operario);
        }

        private bool OperarioExists(int id)
        {
            return _context.Operarios.Any(e => e.Id == id);
        }
    }
}
