namespace Sistema_gestion_funeraria.Models
{
    public partial class Servicio
    {
        public int IdServicio { get; set; }

        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public decimal Costo { get; set; }

        public virtual ICollection<FacturasServicio> FacturasServicios { get; set; } = new List<FacturasServicio>();

        public virtual ICollection<ServiciosCategoria> ServiciosCategoria { get; set; } = new List<ServiciosCategoria>();
    }
}
