namespace Condominio.Models
{
    public class UsuarioModel
    {
        public int Id_Usuario { get; set; }
        public int Id_Persona { get; set; }
        public string Username { get; set; }
        public int Id_Rol { get; set; }
        public int Activo { get; set; }
        public int Primer_Ingreso { get; set; }
        public string Ultimo_Acceso { get; set; }
        public int Intentos_Fallidos { get; set; }
        public int Bloqueado { get; set; }
        public string Fecha_Vencimiento { get; set; }
    }
}
