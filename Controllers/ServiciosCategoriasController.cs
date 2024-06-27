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
    public class ServiciosCategoriasController : ControllerBase
    {
        private readonly FunerariaContext _context;

        public ServiciosCategoriasController(FunerariaContext context)
        {
            _context = context;
        }

        // GET: api/ServiciosCategorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiciosCategoria>>> GetServiciosCategorias()
        {
            return await _context.ServiciosCategorias.ToListAsync();
        }

        // GET: api/ServiciosCategorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiciosCategoria>> GetServiciosCategoria(int id)
        {
            var serviciosCategoria = await _context.ServiciosCategorias.FindAsync(id);

            if (serviciosCategoria == null)
            {
                return NotFound();
            }

            return serviciosCategoria;
        }

        // PUT: api/ServiciosCategorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiciosCategoria(int id, ServiciosCategoria serviciosCategoria)
        {
            if (id != serviciosCategoria.IdServicio)
            {
                return BadRequest();
            }

            _context.Entry(serviciosCategoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciosCategoriaExists(id))
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

        // POST: api/ServiciosCategorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiciosCategoria>> PostServiciosCategoria(ServiciosCategoria serviciosCategoria)
        {
            _context.ServiciosCategorias.Add(serviciosCategoria);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ServiciosCategoriaExists(serviciosCategoria.IdServicio))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetServiciosCategoria", new { id = serviciosCategoria.IdServicio }, serviciosCategoria);
        }

        // DELETE: api/ServiciosCategorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiciosCategoria(int id)
        {
            var serviciosCategoria = await _context.ServiciosCategorias.FindAsync(id);
            if (serviciosCategoria == null)
            {
                return NotFound();
            }

            _context.ServiciosCategorias.Remove(serviciosCategoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiciosCategoriaExists(int id)
        {
            return _context.ServiciosCategorias.Any(e => e.IdServicio == id);
        }
    }
}
