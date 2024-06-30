namespace Sistema_gestion_funeraria.Models
{
    public partial class Localidad
    {
        public int IdLocalidad { get; set; }

        public string Nombre { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

        public virtual ICollection<Sala> Salas { get; set; } = new List<Sala>();
    }
}
