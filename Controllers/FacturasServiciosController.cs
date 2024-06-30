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
    public class FacturasServiciosController : ControllerBase
    {
        private readonly FunerariaContext _context;

        public FacturasServiciosController(FunerariaContext context)
        {
            _context = context;
        }

        // GET: api/FacturasServicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturasServicio>>> GetFacturasServicios()
        {
            return await _context.FacturasServicios.ToListAsync();
        }

        // GET: api/FacturasServicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacturasServicio>> GetFacturasServicio(int id)
        {
            var facturasServicio = await _context.FacturasServicios.FindAsync(id);

            if (facturasServicio == null)
            {
                return NotFound();
            }

            return facturasServicio;
        }

        // PUT: api/FacturasServicios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturasServicio(int id, FacturasServicio facturasServicio)
        {
            if (id != facturasServicio.IdServicio)
            {
                return BadRequest();
            }

            _context.Entry(facturasServicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturasServicioExists(id))
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

        // POST: api/FacturasServicios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FacturasServicio>> PostFacturasServicio(FacturasServicio facturasServicio)
        {
            _context.FacturasServicios.Add(facturasServicio);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FacturasServicioExists(facturasServicio.IdServicio))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFacturasServicio", new { id = facturasServicio.IdServicio }, facturasServicio);
        }

        // DELETE: api/FacturasServicios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturasServicio(int id)
        {
            var facturasServicio = await _context.FacturasServicios.FindAsync(id);
            if (facturasServicio == null)
            {
                return NotFound();
            }

            _context.FacturasServicios.Remove(facturasServicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturasServicioExists(int id)
        {
            return _context.FacturasServicios.Any(e => e.IdServicio == id);
        }
    }
}
