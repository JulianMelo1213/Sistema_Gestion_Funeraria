namespace Sistema_gestion_funeraria.Models
{
    public partial class Atributo
    {
        public int IdAtributo { get; set; }

        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Categoria> IdCategoria { get; set; } = new List<Categoria>();
    }
}