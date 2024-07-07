using System.ComponentModel.DataAnnotations;

namespace Sistema_gestion_funeraria.Models.DTOs.Usuario
{
    public class LoginDTO
    {
        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
