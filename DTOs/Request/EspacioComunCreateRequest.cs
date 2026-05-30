using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class EspacioComunCreateRequest
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "La capacidad es requerida")]
        [Range(1, 1000, ErrorMessage = "La capacidad debe estar entre 1 y 1000 personas")]
        public int Capacidad_Max { get; set; }

        public int Requiere_Reserva { get; set; } = 0;
        public int Tiene_Costo { get; set; } = 0;
        public decimal Costo_Por_Hora { get; set; } = 0;
        public decimal Costo_Por_Dia { get; set; } = 0;
        public decimal Deposito_Garantia { get; set; } = 0;
        public string? Horario_Apertura { get; set; }
        public string? Horario_Cierre { get; set; }
        public string? Reglas { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [RegularExpression("^(DISPONIBLE|EN_MANTENIMIENTO|INACTIVO)$",
            ErrorMessage = "Estado inválido. Use: DISPONIBLE, EN_MANTENIMIENTO o INACTIVO")]
        public string Estado { get; set; } = "DISPONIBLE";

        public int Activo { get; set; } = 1;
    }
}
