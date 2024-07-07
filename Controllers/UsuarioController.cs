﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public UsuarioController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.signInManager = signInManager;
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

                var usuario = new AppUser
                {
                    UserName = registroDTO.NombreUsuario,
                    Nombre = registroDTO.Nombre,
                    Apellido = registroDTO.Apellido,
                    Email = registroDTO.CorreoElectronico,
                };

                var usuarioCreado = await userManager.CreateAsync(usuario, registroDTO.Password);
                if (usuarioCreado.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(usuario, "Usuario");
                    if (roleResult.Succeeded)
                    {
                        var roles = await userManager.GetRolesAsync(usuario);
                        var claims = ClaimsHelper.GenerateClaims(usuario, roles);
                        var token = tokenService.GenerateJWTToken(claims);
                        var refreshToken = await tokenService.StoreRefreshTokenAsync(usuario);

                        return Ok(new NuevoUsuarioDTO
                        {
                            NombreUsuario = usuario.UserName,
                            Nombre = usuario.Nombre,
                            Apellido = usuario.Apellido,
                            Correo = usuario.Email,
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
                    return StatusCode(500, usuarioCreado.Errors);
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

            var usuario = await userManager.FindByNameAsync(loginDTO.NombreUsuario);
            if (usuario != null || await userManager.CheckPasswordAsync(usuario, loginDTO.Password))
            {
                await signInManager.SignInAsync(usuario, isPersistent: false);
                var roles = await userManager.GetRolesAsync(usuario);
                var claims = ClaimsHelper.GenerateClaims(usuario, roles);
                var token = tokenService.GenerateJWTToken(claims);
                var refreshToken = await tokenService.StoreRefreshTokenAsync(usuario);

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
            var usuarioId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (usuarioId == null)
            {
                return BadRequest("No se pudo encontrar el ID de usuario en el token JWT.");
            }

            var usuario = await userManager.FindByIdAsync(usuarioId);

            if (usuario == null)
            {
                return BadRequest("Usuario no encontrado.");
            }

            tokenService.RemoveRefreshTokenAsync(usuario);
            await signInManager.SignOutAsync();

            return Ok("Sesión cerrada correctamente.");
        }
    }
}
