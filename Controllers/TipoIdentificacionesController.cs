using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Sistema_gestion_funeraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoIdentificacionesController : ControllerBase
    {
        private readonly FunerariaContext _context;

        public TipoIdentificacionesController(FunerariaContext context)
        {
            _context = context;
        }

        // GET: api/TipoIdentificaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoIdentificacione>>> GetTipoIdentificaciones()
        {
            return await _context.TipoIdentificaciones.ToListAsync();
        }

        // GET: api/TipoIdentificaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoIdentificacione>> GetTipoIdentificacione(int id)
        {
            var tipoIdentificacione = await _context.TipoIdentificaciones.FindAsync(id);

            if (tipoIdentificacione == null)
            {
                return NotFound();
            }

            return tipoIdentificacione;
        }

        // PUT: api/TipoIdentificaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoIdentificacione(int id, TipoIdentificacione tipoIdentificacione)
        {
            if (id != tipoIdentificacione.IdTipoIdentificacion)
            {
                return BadRequest();
            }

            _context.Entry(tipoIdentificacione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoIdentificacioneExists(id))
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

        // POST: api/TipoIdentificaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoIdentificacione>> PostTipoIdentificacione(TipoIdentificacione tipoIdentificacione)
        {
            _context.TipoIdentificaciones.Add(tipoIdentificacione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoIdentificacione", new { id = tipoIdentificacione.IdTipoIdentificacion }, tipoIdentificacione);
        }

        // DELETE: api/TipoIdentificaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoIdentificacione(int id)
        {
            var tipoIdentificacione = await _context.TipoIdentificaciones.FindAsync(id);
            if (tipoIdentificacione == null)
            {
                return NotFound();
            }

            _context.TipoIdentificaciones.Remove(tipoIdentificacione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoIdentificacioneExists(int id)
        {
            return _context.TipoIdentificaciones.Any(e => e.IdTipoIdentificacion == id);
        }
    }
}
