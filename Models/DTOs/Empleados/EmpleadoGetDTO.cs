using System.ComponentModel.DataAnnotations;

namespace Sistema_gestion_funeraria.Models.DTOs.Empleados
{
    public class EmpleadoGetDTO
    {
        public int IdEmpleado { get; set; }

        public string NumDocumento { get; set; } = null!;

        public int IdTipoIdentificacion { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Direccion { get; set; }

        public string Telefono { get; set; } = null!;

        public int IdCargo { get; set; }

        public int IdJornadaLaboral { get; set; }

        public int IdLocalidad { get; set; }
    }
}
