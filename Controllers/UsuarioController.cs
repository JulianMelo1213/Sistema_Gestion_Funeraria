using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_gestion_funeraria.Helper;
using Sistema_gestion_funeraria.Interface;
using Sistema_gestion_funeraria.Models;
using Sistema_gestion_funeraria.Models.DTOs.Usuario;
using System.Security.Claims;

namespace Sistema_gestion_funeraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ITokenService tokenService;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsuarioController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpPost("registro")]
        public async Task<IActionResult> Registro([FromBody] RegistroDTO registroDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var appUser = new AppUser
                {
                    UserName = registroDTO.NombreUsuario,
                    Nombre = registroDTO.Nombre,
                    Apellido = registroDTO.Apellido,
                    Email = registroDTO.Correo,
                };

                var createdUser = await userManager.CreateAsync(appUser, registroDTO.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(appUser, "Usuario");
                    if (roleResult.Succeeded)
                    {
                        var roles = await userManager.GetRolesAsync(appUser);
                        var claims = ClaimsHelper.GenerateClaims(appUser, roles);
                        var token = tokenService.GenerateJWTToken(claims);

                        var refreshToken = tokenService.GenerateRefreshToken();

                        appUser.RefreshToken = refreshToken;
                        appUser.RefreshTokenExpirationTime = DateTime.Now.AddMinutes(30);

                        await userManager.UpdateAsync(appUser);

                        return Ok(new NuevoUsuarioDTO
                        {
                            NombreUsuario = appUser.UserName,
                            Nombre = appUser.Nombre,
                            Apellido = appUser.Apellido,
                            Correo = appUser.Email,
                            Token = token,
                            RefreshToken = refreshToken
                        });
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

            var appUser = await userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDTO.NombreUsuario);

            if (appUser == null)
            {
                return Unauthorized("Usuario o contraseña inválida");
            }

            var result = await signInManager.CheckPasswordSignInAsync(appUser, loginDTO.Password, false);

            if (result.Succeeded)
            {
                var roles = await userManager.GetRolesAsync(appUser);
                var claims = ClaimsHelper.GenerateClaims(appUser, roles);
                var token = tokenService.GenerateJWTToken(claims);
                var refreshToken = tokenService.GenerateRefreshToken();

                appUser.RefreshToken = refreshToken;
                appUser.RefreshTokenExpirationTime = DateTime.Now.AddMinutes(30);

                await userManager.UpdateAsync(appUser);

                return Ok(new TokenDTO
                {
                    Token = token,
                    RefreshToken = refreshToken
                });
            }
            return Unauthorized("Usuario no encontrado y/o contraseña incorrecta");
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return BadRequest("No se pudo encontrar el ID de usuario en el token JWT.");
            }

            var appUser = await userManager.FindByIdAsync(userId);

            if (appUser == null)
            {
                return BadRequest("Usuario no encontrado.");
            }

            // Eliminar el refresh token y su fecha de expiración
            appUser.RefreshToken = null;

            await userManager.UpdateAsync(appUser);

            return Ok("Sesión cerrada correctamente.");
        }


        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenDTO tokenDTO)
        {
            var principal = tokenService.GetPrincipalFromExpiredToken(tokenDTO.Token);
            var username = principal.Identity.Name; // Obtener el nombre de usuario del token
            var user = await userManager.FindByNameAsync(username); // Buscar el usuario en la base de datos

            // Verificar si el token de refresco está válido para el usuario
            if (user == null || user.RefreshToken != tokenDTO.RefreshToken || user.RefreshTokenExpirationTime <= DateTime.UtcNow)
            {
                return BadRequest("Token inválido o expirado");
            }

            var roles = await userManager.GetRolesAsync(user);
            var claims = ClaimsHelper.GenerateClaims(user, roles);

            var newJwtToken = tokenService.GenerateJWTToken(claims); // Generar un nuevo token JWT
            var newRefreshToken = tokenService.GenerateRefreshToken(); // Generar un nuevo token de refresco

            user.RefreshToken = newRefreshToken; // Actualizar el token de refresco en la base de datos
            await userManager.UpdateAsync(user);

            return Ok(new TokenDTO
            {
                Token = newJwtToken,
                RefreshToken = newRefreshToken
            });
        }
    }
}
