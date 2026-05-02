namespace Condominio.Models
{
    public class LogAuditoriaModel
    {
        public int Id_Log { get; set; }
        public int? Id_Usuario { get; set; }
        public string Username { get; set; }
        public string Modulo { get; set; }
        public string Accion { get; set; }
        public string Tabla_Afectada { get; set; }
        public int? Id_Registro { get; set; }
        public string Descripcion { get; set; }
        public string Ip_Origen { get; set; }
        public string Resultado { get; set; }
        public string Fecha_Hora { get; set; }
    }
}
