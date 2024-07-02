using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_gestion_funeraria.Interface;
using Sistema_gestion_funeraria.Models;
using Sistema_gestion_funeraria.Models.DTOs.Usuario;

namespace Sistema_gestion_funeraria.Controllers
{
    [Authorize(Policy = "RequiereRolAdministrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ITokenService tokenService;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AdministradorController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpPost("añadir-rol")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> AñadirRol([FromBody] CambiarRolDTO cambiarRolDTO)
        {
            try
            {
                var user = await userManager.FindByIdAsync(cambiarRolDTO.IdUsuario);

                if (user == null)
                {
                    return NotFound("Usuario no encontrado");
                }

                var currentRoles = await userManager.GetRolesAsync(user);
                var roleResult = await userManager.AddToRolesAsync(user, cambiarRolDTO.Roles);

                if (!roleResult.Succeeded)
                {
                    return StatusCode(500, roleResult.Errors);
                }

                return Ok("Roles añadidos exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost("quitar-rol")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> QuitarRol([FromBody] CambiarRolDTO cambiarRolDTO)
        {
            try
            {
                var user = await userManager.FindByIdAsync(cambiarRolDTO.IdUsuario);

                if (user == null)
                {
                    return NotFound("Usuario no encontrado");
                }

                var currentRoles = await userManager.GetRolesAsync(user);
                var roleResult = await userManager.RemoveFromRolesAsync(user, cambiarRolDTO.Roles);

                if (!roleResult.Succeeded)
                {
                    return StatusCode(500, roleResult.Errors);
                }

                return Ok("Roles eliminados exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("roles")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<IEnumerable<string>>> GetRoles()
        {
            var roles = await roleManager.Roles.Select(r => r.Name).ToListAsync();
            return Ok(roles);
        }
    }
}
