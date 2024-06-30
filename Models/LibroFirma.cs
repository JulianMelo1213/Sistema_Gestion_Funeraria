namespace Sistema_gestion_funeraria.Models
{
    public partial class LibroFirma
    {
        public int IdLibroFirma { get; set; }

        public int IdDifunto { get; set; }

        public string NombreFirma { get; set; } = null!;

        public string? Mensaje { get; set; }

        public virtual Difunto IdDifuntoNavigation { get; set; } = null!;
    }
}
