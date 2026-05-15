namespace Condominio.Models
{
    public class FamiliarResidenteModel
    {
        public int IdFamiliar { get; set; }
        public int IdResidente { get; set; }
        public int IdPersona { get; set; }
        public int? IdParentesco { get; set; }
        public string? Observaciones { get; set; }
        public int Activo { get; set; } = 1;

        // Campos enriquecidos para mostrar en listados
        public string? NombrePersona { get; set; }
        public string? NombreParentesco { get; set; }
    }
}