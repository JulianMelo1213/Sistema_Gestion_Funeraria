using System.ComponentModel.DataAnnotations;

namespace Sistema_gestion_funeraria.Models.DTOs.Usuario
{
    public class RegistroDTO
    {
        [Required]
        public string? NombreUsuario { get; set; }

        [Required]
        [EmailAddress]
        public string? Correo { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
