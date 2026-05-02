namespace Condominio.DTOs.Request
{
    public class CargoCreateRequest
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? Salario_Base { get; set; }
        public int Activo { get; set; } = 1;
    }
}
