using System.ComponentModel.DataAnnotations;

namespace Sistema_gestion_funeraria.Models.DTOs.TipoIdentificaciones
{
    public class TipoIdentificacioneInsertDTO
    {
        [Required(ErrorMessage = "Nombre es requerido")]
        [MaxLength(100, ErrorMessage = "Nombre no puede ser mayor a 100 carácteres")]
        public string Nombre { get; set; } = null!;
    }
}
