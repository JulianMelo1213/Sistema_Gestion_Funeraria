using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_gestion_funeraria.Models;
using Sistema_gestion_funeraria.Models.DTOs.Empleados;
using Sistema_gestion_funeraria.Helper.Query;

namespace Sistema_gestion_funeraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly FunerariaContext context;
        private readonly IMapper mapper;
        private readonly ILogger<EmpleadoController> logger;

        public EmpleadoController(FunerariaContext context, IMapper mapper, ILogger<EmpleadoController> logger)
        {
            this.context = context;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoGetDTO>>> GetEmpleados([FromQuery] EmpleadoQueryObject query)
        {
            var empleados = context.Empleados.AsQueryable();

            if (query != null)
            {
                empleados = query switch
                {
                    _ when !string.IsNullOrWhiteSpace(query.NumDocumento) => empleados.Where(s => s.NumDocumento.Contains(query.NumDocumento)),
                    _ when !string.IsNullOrWhiteSpace(query.Nombre) => empleados.Where(s => s.Nombre.Contains(query.Nombre)),
                    _ when !string.IsNullOrWhiteSpace(query.Telefono) => empleados.Where(s => s.Telefono.Contains(query.Telefono)),
                    _ => empleados
                };
            }

            var empleadosList = await empleados.ToListAsync();
            var empleadosDto = mapper.Map<IEnumerable<EmpleadoGetDTO>>(empleadosList);
            return Ok(empleadosDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoGetDTO>> GetEmpleado([FromRoute] int id)
        {
            var empleado = await context.Empleados.FindAsync(id);

            if (empleado == null)
            {
                return NotFound(new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Empleado no encontrado",
                    Detail = $"No se encontró un empleado con el ID {id}.",
                    Instance = HttpContext.Request.Path
                });
            }

            var empleadoDto = mapper.Map<EmpleadoGetDTO>(empleado);
            return empleadoDto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado([FromRoute] int id, [FromBody] EmpleadoUpdateDTO empleadoDto)
        {
            if (id != empleadoDto.IdEmpleado)
            {
                return BadRequest(new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "ID no coincide",
                    Detail = "El ID proporcionado no coincide con el ID del empleado.",
                    Instance = HttpContext.Request.Path
                });
            }

            var empleado = mapper.Map<Empleado>(empleadoDto);
            context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await EmpleadoExists(id))
                {
                    return NotFound(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title = "Empleado no encontrado",
                        Detail = $"No se encontró un empleado con el ID {id}.",
                        Instance = HttpContext.Request.Path
                    });
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado([FromBody] EmpleadoInsertDTO empleadoDto)
        {
            var empleado = mapper.Map<Empleado>(empleadoDto);

            if (await EmpleadoExists(empleado?.NumDocumento))
            {
                return BadRequest(new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "ID no coincide",
                    Detail = "El ID proporcionado no coincide con el ID del empleado.",
                    Instance = HttpContext.Request.Path
                });
            }

            await context.Empleados.AddAsync(empleado);
            await context.SaveChangesAsync();

            return Ok(empleado.IdEmpleado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado([FromRoute] int id)
        {
            var empleado = await context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound(new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Empleado no encontrado",
                    Detail = $"No se encontró un empleado con el ID {id}.",
                    Instance = HttpContext.Request.Path
                });
            }

            context.Empleados.Remove(empleado);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> EmpleadoExists(int id)
        {
            bool existe = await context.Empleados.AnyAsync(x => x.IdEmpleado == id);
            logger.LogInformation($"Empleado con {id}: {(existe ? "existe" : "No existe")}.");
            return existe;
        }

        private async Task<bool> EmpleadoExists(string numDocumento)
        {
            bool existe = await context.Empleados.AnyAsync(x => x.NumDocumento == numDocumento);
            logger.LogInformation($"Empleado con número de documento \"{numDocumento}\": {(existe ? "existe" : "No existe")}.");
            return existe;
        }
    }
}
