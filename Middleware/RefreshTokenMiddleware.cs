using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Sistema_gestion_funeraria.Interface;
using Sistema_gestion_funeraria.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_gestion_funeraria.Middleware
{
    public class RefreshTokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<RefreshTokenMiddleware> _logger;

        public RefreshTokenMiddleware(RequestDelegate next, IServiceProvider serviceProvider, ILogger<RefreshTokenMiddleware> logger)
        {
            _next = next;
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var accessToken = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            // Si no hay token de acceso, continuar con la solicitud sin refrescar
            if (string.IsNullOrEmpty(accessToken))
            {
                await _next(context);
                return;
            }

            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var tokenService = scope.ServiceProvider.GetRequiredService<ITokenService>();
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                    var principal = tokenService.GetPrincipalFromExpiredToken(accessToken);
                    if (principal != null)
                    {
                        var nombreUsuario = principal.Identity.Name;
                        var usuario = await userManager.FindByNameAsync(nombreUsuario);
                        if (usuario != null && usuario.RefreshToken == null)
                        {
                            await tokenService.StoreRefreshTokenAsync(usuario);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred during token refresh.");
                // Puedes manejar el error aquí según tus necesidades
            }

            await _next(context);
        }
    }
}
