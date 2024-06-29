using System.ComponentModel.DataAnnotations;

namespace Sistema_gestion_funeraria.Models.DTOs.Empleados
{
    public class EmpleadoInsertDTO
    {
        [Required(ErrorMessage = "Nombre es requerido")]
        [MaxLength(100, ErrorMessage = "Nombre no puede ser mayor a 100 carácteres")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "Número de Documento es requerido")]
        [MinLength(11, ErrorMessage = "Número de Documento no puede ser menor a 9 carácteres")]
        [MaxLength(11, ErrorMessage = "Número de Documento no puede ser mayor a 11 carácteres")]
        public string? NumDocumento { get; set; }

        [Required(ErrorMessage = "Dirección es requerida")]
        [MaxLength(200, ErrorMessage = "Dirección no puede ser mayor a 200 carácteres")]
        public string Direccion { get; set; } = null!;

        [Required(ErrorMessage = "Teléfono es requerido")]
        [MaxLength(10, ErrorMessage = "Teléfono no puede ser mayor a 10 carácteres")]
        public string Telefono { get; set; } = null!;

        [Required(ErrorMessage = "Tipo de Identificación es requerido")]
        public int? IdTipoIdentificacion { get; set; }

        [Required(ErrorMessage = "Tipo de Cargo es requerido")]
        public int? IdCargo { get; set; }

        [Required(ErrorMessage = "La Jornada Laboral asociada requerida")]
        public int? IdJornadaLaboral { get; set; }

        [Required(ErrorMessage = "La Localidad asociada requerida")]
        public int? IdLocalidad { get; set; }
    }
}
