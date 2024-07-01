namespace Sistema_gestion_funeraria.Models.DTOs.Usuario
{
    public class CambiarRolDTO
    {
        public string IdUsuario { get; set; }
        public IList<string> Roles { get; set; }
    }
}
