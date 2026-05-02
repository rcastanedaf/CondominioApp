namespace Condominio.DTOs.Request
{
    public class EspacioComunCreateRequest
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Capacidad_Max { get; set; }
        public int Requiere_Reserva { get; set; } = 1;
        public int Tiene_Costo { get; set; } = 0;
        public decimal Costo_Por_Hora { get; set; } = 0;
        public decimal Costo_Por_Dia { get; set; } = 0;
        public decimal Deposito_Garantia { get; set; } = 0;
        public string Horario_Apertura { get; set; }
        public string Horario_Cierre { get; set; }
        public string Reglas { get; set; }
        public string Estado { get; set; } = "DISPONIBLE";
        public int Activo { get; set; } = 1;

    }
}
