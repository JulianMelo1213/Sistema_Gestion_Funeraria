using Microsoft.AspNetCore.Authorization;

namespace Sistema_gestion_funeraria.Helper
{
    public class AuthorizationPoliciesHelper
    {
        public static void AddPolicies(AuthorizationOptions options)
        {
            options.AddPolicy("AdministradorPolicy", policy => policy.RequireRole("Administrador"));
            options.AddPolicy("UsuarioPolicy", policy => policy.RequireRole("Usuario"));
        }
    }
}
