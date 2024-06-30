using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_gestion_funeraria.Models;

namespace Sistema_gestion_funeraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JornadaLaboralesController : ControllerBase
    {
        private readonly FunerariaContext _context;

        public JornadaLaboralesController(FunerariaContext context)
        {
            _context = context;
        }

        // GET: api/JornadaLaborales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JornadaLaborale>>> GetJornadaLaborales()
        {
            return await _context.JornadaLaborales.ToListAsync();
        }

        // GET: api/JornadaLaborales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JornadaLaborale>> GetJornadaLaborale(int id)
        {
            var jornadaLaborale = await _context.JornadaLaborales.FindAsync(id);

            if (jornadaLaborale == null)
            {
                return NotFound();
            }

            return jornadaLaborale;
        }

        // PUT: api/JornadaLaborales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJornadaLaborale(int id, JornadaLaborale jornadaLaborale)
        {
            if (id != jornadaLaborale.IdJornadaLaboral)
            {
                return BadRequest();
            }

            _context.Entry(jornadaLaborale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JornadaLaboraleExists(id))
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

        // POST: api/JornadaLaborales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JornadaLaborale>> PostJornadaLaborale(JornadaLaborale jornadaLaborale)
        {
            _context.JornadaLaborales.Add(jornadaLaborale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJornadaLaborale", new { id = jornadaLaborale.IdJornadaLaboral }, jornadaLaborale);
        }

        // DELETE: api/JornadaLaborales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJornadaLaborale(int id)
        {
            var jornadaLaborale = await _context.JornadaLaborales.FindAsync(id);
            if (jornadaLaborale == null)
            {
                return NotFound();
            }

            _context.JornadaLaborales.Remove(jornadaLaborale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JornadaLaboraleExists(int id)
        {
            return _context.JornadaLaborales.Any(e => e.IdJornadaLaboral == id);
        }
    }
}
