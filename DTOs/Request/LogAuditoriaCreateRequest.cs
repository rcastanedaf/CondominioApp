namespace Condominio.DTOs.Request
{
    public class LogAuditoriaCreateRequest
    {
        public int? Id_Usuario { get; set; }
        public string Username { get; set; }
        public string Modulo { get; set; }
        public string Accion { get; set; }
        public string Tabla_Afectada { get; set; }
        public int? Id_Registro { get; set; }
        public string Descripcion { get; set; }
        public string Datos_Anteriores { get; set; }
        public string Datos_Nuevos { get; set; }
        public string Ip_Origen { get; set; }
        public string Resultado { get; set; } = "EXITO"; 
        public string Mensaje_Error { get; set; }
    }
}
