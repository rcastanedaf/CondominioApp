namespace Condominio.Models
{
    public class ProveedorModel
    {
        public int Id_Proveedor { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Nit { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public string? Contacto { get; set; }
        public string? Especialidad { get; set; }
        public int Activo { get; set; } = 1;
        public string? Fecha_Registro { get; set; }
    }
}