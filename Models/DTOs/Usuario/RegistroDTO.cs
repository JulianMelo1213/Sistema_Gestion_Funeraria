using System.ComponentModel.DataAnnotations;

namespace Sistema_gestion_funeraria.Models.DTOs.Usuario
{
    public class RegistroDTO
    {
        [Required]
        public string? NombreUsuario { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Nombre no puede ser mayor a 100 carácteres")]
        public string? Nombre { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Apellido no puede ser mayor a 100 carácteres")]
        public string? Apellido { get; set; }

        [Required]
        [EmailAddress]
        public string? CorreoElectronico { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
