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
    public class AtributoesController : ControllerBase
    {
        private readonly FunerariaContext _context;

        public AtributoesController(FunerariaContext context)
        {
            _context = context;
        }

        // GET: api/Atributoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atributo>>> GetAtributos()
        {
            return await _context.Atributos.ToListAsync();
        }

        // GET: api/Atributoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Atributo>> GetAtributo(int id)
        {
            var atributo = await _context.Atributos.FindAsync(id);

            if (atributo == null)
            {
                return NotFound();
            }

            return atributo;
        }

        // PUT: api/Atributoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtributo(int id, Atributo atributo)
        {
            if (id != atributo.IdAtributo)
            {
                return BadRequest();
            }

            _context.Entry(atributo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtributoExists(id))
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

        // POST: api/Atributoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Atributo>> PostAtributo(Atributo atributo)
        {
            _context.Atributos.Add(atributo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtributo", new { id = atributo.IdAtributo }, atributo);
        }

        // DELETE: api/Atributoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtributo(int id)
        {
            var atributo = await _context.Atributos.FindAsync(id);
            if (atributo == null)
            {
                return NotFound();
            }

            _context.Atributos.Remove(atributo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AtributoExists(int id)
        {
            return _context.Atributos.Any(e => e.IdAtributo == id);
        }
    }
}
