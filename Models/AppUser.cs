using Microsoft.AspNetCore.Identity;

namespace Sistema_gestion_funeraria.Models
{
    public class AppUser: IdentityUser
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpirationTime { get; set; }
    }
}
