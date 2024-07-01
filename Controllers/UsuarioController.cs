using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_gestion_funeraria.Helper;
using Sistema_gestion_funeraria.Models;
using Sistema_gestion_funeraria.Models.DTOs.Usuario;

namespace Sistema_gestion_funeraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;

        private readonly AuthenticationHelper tokenHelper;

        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsuarioController(UserManager<AppUser> userManager, AuthenticationHelper tokenHelper, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.tokenHelper = tokenHelper;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Registro([FromBody] RegistroDTO registroDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var appUser = new AppUser
                {
                    UserName = registroDTO.NombreUsuario,
                    Email = registroDTO.Correo,
                };

                var createdUser = await userManager.CreateAsync(appUser, registroDTO.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(appUser, "Usuario");
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NuevoUsuarioDTO
                            {
                                NombreUsuario = appUser.UserName,
                                Correo = appUser.Email,
                                Token = tokenHelper.GenerateJWTToken(appUser)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }

                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpPost("login")]

        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDTO.NombreUsuario.ToLower());

            if (user == null)
            {
                return Unauthorized("Usuario o contraseña inválida");
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

            if (result.Succeeded)
            {
                // Obtener roles del usuario
                var roles = await userManager.GetRolesAsync(user);

                // Generar token JWT con roles incluidos
                var token = tokenHelper.GenerateJWTToken(user, roles);

                // Retornar respuesta con token y otros datos del usuario
                return Ok(new NuevoUsuarioDTO
                {
                    NombreUsuario = user.UserName,
                    Correo = user.Email,
                    Token = token
                });
            }

            // Autenticación fallida
            return Unauthorized("Usuario no encontrado y/o contraseña incorrecta");
        }

        [HttpPost("añadirrol")]
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

        [HttpPost("quitarrol")]
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

        [HttpPost("verroles")]
        [Authorize(Roles = "Administrador")]
        private async Task<ActionResult<IEnumerable<IdentityRole>>> GetRoles()
        {
            return await roleManager.Roles.ToListAsync();
        }
    }
}
