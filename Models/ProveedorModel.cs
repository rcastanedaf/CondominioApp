namespace Condominio.Models
{
    public class ProveedorModel
    {
        public int Id_Proveedor { get; set; } 
        public string Nombre_Empresa { get; set; }
        public string Nit { get; set; } 
        public string Rubro { get; set; } 
        public string Telefono { get; set; }
        public string Email { get; set; } 
        public string Contacto_Nombre { get; set; }
        public string Contacto_Telefono { get; set; }
        public string Direccion { get; set; } 
        public int Activo { get; set; } 
        public string Observaciones { get; set; }
    }
}
