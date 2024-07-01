using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_gestion_funeraria.Models;
using Sistema_gestion_funeraria.Models.DTOs.TipoIdentificaciones;

namespace Sistema_gestion_funeraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoIdentificacionesController : ControllerBase
    {
        private readonly FunerariaContext _context;
        private readonly IMapper _mapper;

        public TipoIdentificacionesController(FunerariaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/TipoIdentificaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoIdentificacioneGetDTO>>> GetTipoIdentificaciones()
        {
            var tipoIdentificacionesList = await _context.TipoIdentificaciones.ToListAsync(); 
            var tiposIdentificacionesDtos= _mapper.Map<IEnumerable<TipoIdentificacioneGetDTO>>(tipoIdentificacionesList);
            return Ok(tiposIdentificacionesDtos);
        }

        // GET: api/TipoIdentificaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoIdentificacioneGetDTO>> GetTipoIdentificacione(int id)
        {
            var tipoIdentificacione = await _context.TipoIdentificaciones.FindAsync(id);

            if (tipoIdentificacione == null)
            {
                return NotFound();
            }

            var tipoIdentificacionDto = _mapper.Map<TipoIdentificacioneGetDTO>(tipoIdentificacione);
            return tipoIdentificacionDto;
        }

        // PUT: api/TipoIdentificaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoIdentificacione(int id, TipoIdentificacioneUpdateDTO tipoIdentificacioneDto)
        {
            if (id != tipoIdentificacioneDto.IdTipoIdentificacion)
            {
                return BadRequest();
            }

            var tipoIdentificacione = _mapper.Map<TipoIdentificacione>(tipoIdentificacioneDto);

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
        public async Task<ActionResult<TipoIdentificacione>> PostTipoIdentificacione(TipoIdentificacioneInsertDTO tipoIdentificacioneDto)
        {
            var tipoIdentificacione = _mapper.Map<TipoIdentificacione>(tipoIdentificacioneDto);

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

        private async Task<bool> TipoIdentificacioneExists(int id)
        {
            return await _context.TipoIdentificaciones.AnyAsync(e => e.IdTipoIdentificacion == id);
        }
    }
}
