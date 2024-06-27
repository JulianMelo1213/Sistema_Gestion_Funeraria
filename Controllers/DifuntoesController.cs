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
    public class DifuntoesController : ControllerBase
    {
        private readonly FunerariaContext _context;

        public DifuntoesController(FunerariaContext context)
        {
            _context = context;
        }

        // GET: api/Difuntoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Difunto>>> GetDifuntos()
        {
            return await _context.Difuntos.ToListAsync();
        }

        // GET: api/Difuntoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Difunto>> GetDifunto(int id)
        {
            var difunto = await _context.Difuntos.FindAsync(id);

            if (difunto == null)
            {
                return NotFound();
            }

            return difunto;
        }

        // PUT: api/Difuntoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDifunto(int id, Difunto difunto)
        {
            if (id != difunto.IdDifunto)
            {
                return BadRequest();
            }

            _context.Entry(difunto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DifuntoExists(id))
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

        // POST: api/Difuntoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Difunto>> PostDifunto(Difunto difunto)
        {
            _context.Difuntos.Add(difunto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDifunto", new { id = difunto.IdDifunto }, difunto);
        }

        // DELETE: api/Difuntoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDifunto(int id)
        {
            var difunto = await _context.Difuntos.FindAsync(id);
            if (difunto == null)
            {
                return NotFound();
            }

            _context.Difuntos.Remove(difunto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DifuntoExists(int id)
        {
            return _context.Difuntos.Any(e => e.IdDifunto == id);
        }
    }
}
