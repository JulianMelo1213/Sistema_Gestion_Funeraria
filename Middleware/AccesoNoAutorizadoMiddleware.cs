using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Sistema_gestion_funeraria.Middleware
{
    public class AccesoNoAutorizadoMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ManejadorExcepcionMiddleware> _logger;

        public AccesoNoAutorizadoMiddleware(RequestDelegate next, ILogger<ManejadorExcepcionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ManejarSolicitudAsync(context);
            }
        }

        private static Task ManejarSolicitudAsync(HttpContext context)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Title = "No autorizado",
                Detail = "Token faltante para el acceso a la API",
                Instance = context.Request.Path
            };

            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;

            var json = JsonSerializer.Serialize(problemDetails);
            return context.Response.WriteAsync(json);
        }

    }
}
