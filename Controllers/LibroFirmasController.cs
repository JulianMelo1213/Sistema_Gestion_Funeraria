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
    public class LibroFirmasController : ControllerBase
    {
        private readonly FunerariaContext _context;

        public LibroFirmasController(FunerariaContext context)
        {
            _context = context;
        }

        // GET: api/LibroFirmas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroFirma>>> GetLibroFirmas()
        {
            return await _context.LibroFirmas.ToListAsync();
        }

        // GET: api/LibroFirmas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LibroFirma>> GetLibroFirma(int id)
        {
            var libroFirma = await _context.LibroFirmas.FindAsync(id);

            if (libroFirma == null)
            {
                return NotFound();
            }

            return libroFirma;
        }

        // PUT: api/LibroFirmas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibroFirma(int id, LibroFirma libroFirma)
        {
            if (id != libroFirma.IdLibroFirma)
            {
                return BadRequest();
            }

            _context.Entry(libroFirma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroFirmaExists(id))
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

        // POST: api/LibroFirmas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LibroFirma>> PostLibroFirma(LibroFirma libroFirma)
        {
            _context.LibroFirmas.Add(libroFirma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibroFirma", new { id = libroFirma.IdLibroFirma }, libroFirma);
        }

        // DELETE: api/LibroFirmas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibroFirma(int id)
        {
            var libroFirma = await _context.LibroFirmas.FindAsync(id);
            if (libroFirma == null)
            {
                return NotFound();
            }

            _context.LibroFirmas.Remove(libroFirma);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibroFirmaExists(int id)
        {
            return _context.LibroFirmas.Any(e => e.IdLibroFirma == id);
        }
    }
}
