using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class EspacioComunCreateRequest
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Descripcion { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Capacidad_Max { get; set; }

        [Range(0, 1)]
        public int Requiere_Reserva { get; set; } = 1;

        [Range(0, 1)]
        public int Tiene_Costo { get; set; } = 0;

        [Range(0, double.MaxValue)]
        public decimal Costo_Por_Hora { get; set; } = 0;

        [Range(0, double.MaxValue)]
        public decimal Costo_Por_Dia { get; set; } = 0;

        [Range(0, double.MaxValue)]
        public decimal Deposito_Garantia { get; set; } = 0;

        [StringLength(50)]
        public string? Horario_Apertura { get; set; }

        [StringLength(50)]
        public string? Horario_Cierre { get; set; }

        [StringLength(500)]
        public string? Reglas { get; set; }

        [Required]
        public string Estado { get; set; } = "DISPONIBLE";

        [Range(0,1)]
        public int Activo { get; set; } = 1;
    }
}