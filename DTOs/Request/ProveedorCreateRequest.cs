namespace Condominio.DTOs.Request
{
    public class ProveedorCreateRequest
    {
        public string Nombre_Empresa { get; set; }
        public string Nit { get; set; }
        public string Rubro { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Contacto_Nombre { get; set; }
        public string Contacto_Telefono { get; set; }
        public string Direccion { get; set; }
        public int Activo { get; set; } = 1;
        public string Observaciones { get; set; }
    }
}
