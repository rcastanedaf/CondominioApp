namespace Condominio.Models
{
    public class CargoModel
    {
        public int Id_Cargo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? Salario_Base { get; set; }
        public int Activo { get; set; }
    }
}
