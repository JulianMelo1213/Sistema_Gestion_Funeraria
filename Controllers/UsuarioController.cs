using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Sistema_gestion_funeraria.Helper;
using Sistema_gestion_funeraria.Models;
using Sistema_gestion_funeraria.Models.DTOs.Usuario;
using System.Runtime.CompilerServices;

namespace Sistema_gestion_funeraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;

        private readonly AuthenticationHelper tokenHelper;

        private readonly SignInManager<AppUser> signInManager;

        public UsuarioController(UserManager<AppUser> userManager, AuthenticationHelper tokenHelper, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.tokenHelper = tokenHelper;
            this.signInManager = signInManager;
        }

        [HttpPost("Registro")]
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

        [HttpPost("Login")]

        public async Task<IActionResult> login(LoginDTO loginDTO)
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

            if (!result.Succeeded)
            {
                return Unauthorized("Usuario no encontrado y/o contraseña incorrecta");
            }

            return Ok(
                new NuevoUsuarioDTO
                {
                    NombreUsuario = user.UserName,
                    Correo = user.Email,
                    Token = tokenHelper.GenerateJWTToken(user)
                }
            );
        }
    }
}
