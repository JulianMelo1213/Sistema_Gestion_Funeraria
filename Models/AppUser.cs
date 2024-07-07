using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace Sistema_gestion_funeraria.Models
{
    public class AppUser: IdentityUser
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        [JsonIgnore]
        public string? Token { get; set; }
        [JsonIgnore]
        public string? RefreshToken { get; set; }
        [JsonIgnore]
        public DateTime RefreshTokenExpirationTime { get; set; }
    }
}
