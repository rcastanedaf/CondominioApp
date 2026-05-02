namespace Condominio.DTOs.Request
{
    public class UsuarioCreateRequest
    {
        public int Id_Persona { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Id_Rol { get; set; }
        public int Activo { get; set; } = 1; 
        public string Fecha_Vencimiento { get; set; }
    }
}
