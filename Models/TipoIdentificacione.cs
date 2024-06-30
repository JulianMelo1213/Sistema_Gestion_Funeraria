namespace Sistema_gestion_funeraria.Models
{
    public partial class TipoIdentificacione
    {
        public int IdTipoIdentificacion { get; set; }

        public string Nombre { get; set; } = null!;

        public virtual Difunto? Difunto { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
    }
}
