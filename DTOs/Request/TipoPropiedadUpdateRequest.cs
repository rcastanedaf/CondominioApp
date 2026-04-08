namespace Condominio.DTOs.Request
{
    public class TipoPropiedadUpdateRequest
    {
        public required int Id_Tipo_Propiedad { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
    }
}
