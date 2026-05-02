namespace Condominio.DTOs.Request
{
    public class UsuarioUpdateRequest
    {
        public int Id_Usuario { get; set; }
        public int Id_Rol { get; set; }
        public int Activo { get; set; }
        public string Fecha_Vencimiento { get; set; }
    }
}
