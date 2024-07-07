using Microsoft.AspNetCore.Authorization;

namespace Sistema_gestion_funeraria.Helper
{
    public class PoliciesHelper
    {
        public static void AddPolicies(AuthorizationOptions options)
        {
            options.AddPolicy("RequiereRolAdministrador", policy => policy.RequireRole("Administrador"));
            options.AddPolicy("RequiereRolUsuario", policy => policy.RequireRole("Usuario"));
        }
    }
}
